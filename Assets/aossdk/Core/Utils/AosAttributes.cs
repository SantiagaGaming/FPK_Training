using System;

namespace AosSdk.Core.Utils
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AosAction : Attribute
    {
        public readonly string ActionName;

        public AosAction(string name)
        {
            ActionName = name;
        }
    }

    [AttributeUsage(AttributeTargets.Event)]
    public class AosEvent : Attribute
    {
        public readonly string EventName;

        public AosEvent(string name)
        {
            EventName = name;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class AosObject : Attribute
    {
        public readonly string ObjectName;

        public AosObject(string name)
        {
            ObjectName = name;
        }
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    public class AosParameter : Attribute
    {
        public readonly string ParameterName;

        public AosParameter(string name)
        {
            ParameterName = name;
        }
    }
}