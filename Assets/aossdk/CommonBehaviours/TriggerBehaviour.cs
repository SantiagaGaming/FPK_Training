using System.Collections.Generic;
using System.Linq;
using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.CommonBehaviours
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class TriggerBehaviour : AosObjectBase
    {
        [AosEvent(name: "При попадании объекта в триггер")]
        public event AosEventHandlerWithAttribute OnObjectTriggerEnter;

        [AosEvent(name: "При выходе объекта из триггера")]
        public event AosEventHandlerWithAttribute OnObjectTriggerExit;

        [AosEvent(name: "При нахождении объекта в триггере")]
        public event AosEventHandlerWithAttribute OnObjectTriggerStay;

        [AosAction("Проверить, находится ли объект в триггере")]
        public bool IsObjectInTrigger([AosParameter("guid объекта")] string objectGuid) => (bool) ObjectsInTrigger.FirstOrDefault(item => item.ObjectId == objectGuid);

        public IEnumerable<AosObjectBase> ObjectsInTrigger => _collidedObjects.Keys.Select(a => a).ToList();

        private void Awake()
        {
            GetComponent<Collider>().isTrigger = true;
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }

        private readonly Dictionary<AosObjectBase, int> _collidedObjects = new Dictionary<AosObjectBase, int>();

        private const int ExitFramesCount = 5;

        private void OnTriggerStay(Collider other)
        {
            var aosObject = other.GetComponentInParent<AosObjectBase>();
            if (!aosObject)
            {
                return;
            }

            if (!_collidedObjects.ContainsKey(aosObject))
            {
                Debug.Log(aosObject.name + "Entered");
                OnObjectTriggerEnter?.Invoke(aosObject.ObjectId);
                _collidedObjects.Add(aosObject, ExitFramesCount);
            }
            else
            {
                OnObjectTriggerStay?.Invoke(aosObject.ObjectId);
                _collidedObjects[aosObject] = ExitFramesCount;
            }
        }

        private void FixedUpdate()
        {
            foreach (var aosObject in _collidedObjects.Keys.ToArray())
            {
                _collidedObjects[aosObject]--;
                if (_collidedObjects[aosObject] >= 0)
                {
                    continue;
                }

                Debug.Log(aosObject.name + "Exited");
                OnObjectTriggerExit?.Invoke(aosObject.ObjectId);
                _collidedObjects.Remove(aosObject);
            }
        }
    }
}