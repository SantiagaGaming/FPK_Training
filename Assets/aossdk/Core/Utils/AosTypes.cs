using System;

namespace AosSdk.Core.Utils
{
    [Serializable]
    public class AosObjectType
    {
        public string aosObjectDescription;
        public string aosObjectGuid;
        public AosActionType[] aosObjectActions;
        public AosEventType[] aosObjectEvents;
    }

    [Serializable]
    public class AosActionType
    {
        public string methodDescription;
        public string methodName;
        public string returnType;
        public AosActionParameterInfoType[] parameters;
    }

    [Serializable]
    public class AosActionParameterInfoType
    {
        public string parameterDescription;
        public string parameterName;
        public string parameterType;
    }

    [Serializable]
    public class AosEventType
    {
        public string eventDescription;
        public string eventName;
    }

    [Serializable]
    public class AosCommand
    {
        public string objectGuid;
        public string methodName;
        public AosParameterType[] parameters;
        public float delay;
        public object[] CastedParameters;

        public void CastParameters()
        {
            CastedParameters = new object[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                var value = parameters[i].parameterValue;

                switch (parameters[i].parameterType)
                {
                    case "Boolean":
                    case "bool":
                        CastedParameters[i] = bool.Parse(value);
                        break;
                    case "Int32":
                    case "int":
                        CastedParameters[i] = int.Parse(value);
                        break;
                    case "Single":
                    case "float":
                        CastedParameters[i] = float.Parse(value);
                        break;
                    case "String":
                    case "string":
                        CastedParameters[i] = value;
                        break;
                    default:
                        CastedParameters[i] = null;
                        break;
                }
            }
        }
    }

    [Serializable]
    public class AosParameterType
    {
        public string parameterName;
        public string parameterType;
        public string parameterValue;
    }

    public class EventHandlerHelper
    {
        public string GameObjectGuid;
        public string EventName;
    }

    public enum ServerMessageType
    {
        Callback,
        Event,
        Error
    }

    [Serializable]
    public class ServerMessage
    {
        public string type;
        public string objectGuid;
    }

    [Serializable]
    public class ServerMessageError : ServerMessage
    {
        public string errorMessage;
    }

    [Serializable]
    public class ServerMessageCallback : ServerMessage
    {
        public string invokedMethod;
        public bool isSuccess;
        public string returnValue;
    }

    [Serializable]
    public class ServerMessageEvent : ServerMessage
    {
        public string eventName;
        public string castedToStringAttribute;
    }
}