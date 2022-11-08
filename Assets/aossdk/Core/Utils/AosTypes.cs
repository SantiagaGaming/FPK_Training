using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace AosSdk.Core.Utils
{
    [Serializable]
    public class AosObjectType
    {
        public string aosObjectDescription;
        public string aosObjectId;
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
        public string objectId;
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
                    case "JObject":
                        CastedParameters[i] = TryParseJsonObject(value);
                        break;
                    case "JArray":
                        CastedParameters[i] = TryParseJsonArray(value);
                        break;
                    default:
                        CastedParameters[i] = null;
                        break;
                }
            }
        }

        private object TryParseJsonObject(string json)
        {
            object result = null;

            try
            {
                result = JObject.Parse(json);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }

            return result;
        }

        private object TryParseJsonArray(string json)
        {
            object result = null;

            try
            {
                result = JArray.Parse(json);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }

            return result;
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
        public string GameObjectId;
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
        public string objectId;
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