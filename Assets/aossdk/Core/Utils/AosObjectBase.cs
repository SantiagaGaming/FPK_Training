using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace AosSdk.Core.Utils
{
    [DisallowMultipleComponent]
    public class AosObjectBase : MonoBehaviour
    {
        [field: SerializeField] public string ObjectId { get; set; } = string.Empty;

        public static readonly List<AosObjectBase> AosObjects = new List<AosObjectBase>();

        public delegate void AosEventHandler();

        public delegate void AosEventHandlerWithAttribute(object parameter);

        private readonly List<AosCommand> _commandQueue = new List<AosCommand>();

        [AosAction("Задать активность объекта")]
        public void SetActiveState(bool state)
        {
            gameObject.SetActive(state);
        }

        public static void InheritEventFired(EventHandlerHelper helper)
        {
            WebSocketWrapper.Instance.DoSendMessage(new ServerMessageEvent
            {
                type = ServerMessageType.Event.ToString(),
                eventName = helper.EventName,
                objectId = helper.GameObjectId
            });
        }

        public static void InheritEventWithParameterFired(EventHandlerHelper helper, object attribute)
        {
            WebSocketWrapper.Instance.DoSendMessage(new ServerMessageEvent
            {
                type = ServerMessageType.Event.ToString(),
                eventName = helper.EventName,
                objectId = helper.GameObjectId,
                castedToStringAttribute = attribute.ToString()
            });
        }

        public virtual void OnEnable()
        {
            AosObjects.Add(this);

            foreach (var eventInfo in GetType().GetEvents())
            {
                if (!(Attribute.GetCustomAttribute(eventInfo, typeof(AosEvent)) is AosEvent))
                {
                    continue;
                }

                var handlerType = eventInfo.EventHandlerType;

                var invokeParameters = handlerType.GetMethod("Invoke")?.GetParameters();

                if (invokeParameters == null)
                {
                    Debug.LogError($"Invoke for {handlerType.Name} is broken!");
                    return;
                }

                var eventHandler = GetType().GetMethod(invokeParameters.Length == 0 ? "InheritEventFired" : "InheritEventWithParameterFired",
                    BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static);

                var eventHandlerHelper = new EventHandlerHelper {GameObjectId = ObjectId, EventName = eventInfo.Name};
                var delegateMethod = Delegate.CreateDelegate(handlerType, eventHandlerHelper, eventHandler ?? throw new InvalidOperationException());
                eventInfo.AddEventHandler(this, delegateMethod);
            }
        }

        public void QueueCommand(AosCommand command)
        {
            _commandQueue.Add(command);
        }

        public virtual void FixedUpdate()
        {
            if (_commandQueue.Count <= 0)
            {
                return;
            }

            StartCoroutine(ExecuteCommandRoutine(_commandQueue[0]));

            _commandQueue.RemoveAt(0);
        }

        private IEnumerator ExecuteCommandRoutine(AosCommand command)
        {
            yield return new WaitForSeconds(command.delay);

            command.CastParameters();

            var parametersType = new Type[command.CastedParameters.Length];

            for (var i = 0; i < command.CastedParameters.Length; i++)
            {
                if (command.CastedParameters[i] == null)
                {
                    ReportError($"Failed to invoke {command.methodName} : can't cast parameter with name {command.parameters[i].parameterName}, check parameter type");
                    yield break;
                }

                parametersType[i] = command.CastedParameters[i].GetType();
            }

            var thisType = GetType();

            var methodInfo = thisType.GetMethod(command.methodName, parametersType);

            if (methodInfo == null)
            {
                var errorMessage = $"Method with name {command.methodName} not found";
                ReportError(errorMessage);
                Debug.LogError(errorMessage);

                yield break;
            }

            var isInvokeWasSuccess = true;
            object returnValue = null;

            try
            {
                returnValue = methodInfo.Invoke(this, command.CastedParameters);
            }
            catch (Exception e)
            {
                var errorMessage = $"Method invoke error: {e.Message}";
                ReportError(errorMessage);
                Debug.LogError(errorMessage);

                isInvokeWasSuccess = false;
            }

            WebSocketWrapper.Instance.DoSendMessage(new ServerMessageCallback
            {
                objectId = ObjectId,
                invokedMethod = methodInfo.Name,
                isSuccess = isInvokeWasSuccess,
                returnValue = returnValue == null ? "null" : returnValue.ToString(),
                type = ServerMessageType.Callback.ToString()
            });
        }

        protected internal void ReportError(string errorMessage)
        {
            WebSocketWrapper.Instance.DoSendMessage(new ServerMessageError
            {
                objectId = ObjectId,
                errorMessage = errorMessage,
                type = ServerMessageType.Error.ToString()
            });
        }
    }
}