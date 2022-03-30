using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.CommonBehaviours
{
    [RequireComponent(typeof(Collider))]
    public class TriggerBehaviour : AosObjectBase
    {
        private readonly List<AosObjectBase> _objectsInTrigger = new List<AosObjectBase>();
        private Collider _thisCollider;

        [AosEvent(name: "При попадании объекта в триггер")]
        public event AosEventHandlerWithAttribute OnObjectTriggerEnter;

        [AosEvent(name: "При попадании объекта в триггер")]
        public event AosEventHandlerWithAttribute OnObjectTriggerExit;

        [AosAction("Проверить, находится ли объект в триггере")]
        public bool IsObjectInTrigger([AosParameter("guid объекта")] string objectGuid)
        {
            return (bool) _objectsInTrigger.FirstOrDefault(item => item.objectStaticGuid == objectGuid);
        }

        private void Awake()
        {
            _thisCollider = GetComponent<Collider>();

            if (_thisCollider.isTrigger)
            {
                return;
            }

            _thisCollider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider col)
        {
            var aosObject = col.GetComponentInParent<AosObjectBase>();
            if (!aosObject)
            {
                return;
            }

            OnObjectTriggerEnter?.Invoke(aosObject.objectStaticGuid);
            _objectsInTrigger.Add(aosObject);
        }

        private void OnTriggerExit(Collider col)
        {
            var aosObject = col.GetComponentInParent<AosObjectBase>();
            if (!aosObject)
            {
                return;
            }

            OnObjectTriggerExit?.Invoke(aosObject.objectStaticGuid);
            _objectsInTrigger.Remove(aosObject);
        }
    }
}