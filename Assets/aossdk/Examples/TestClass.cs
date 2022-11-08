using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AosSdk.Examples
{
    [AosObject(name: "Тестовый объект")]
    public class TestClass : AosObjectBase, IClickAble, IHoverAble
    {
        [AosAction(name: "Тестовый экшен параметрами")]
        public void TestVoidWithParameters([AosParameter("Аргумент 1")] bool arg1, [AosParameter("Аргумент 2")] int arg2,
            [AosParameter("Аргумент 3")] float arg3)
        {
        }

        [AosAction(name: "Тестовый экшен без параметров")]
        public void TestVoid()
        {
        }

        [AosEvent(name: "Тестовое событие")] public event AosEventHandler OnEventHappened;

        [AosEvent(name: "Тестовое событие cо строковым атрибутом")]
        public event AosEventHandlerWithAttribute OnEventWithStringAttributeHappened;

        private void Start()
        {
            OnEventHappened += () => { Debug.Log("Test class event fired"); };
            OnEventWithStringAttributeHappened += stringAttribute => { Debug.Log($"Test class event with string parameter \"{stringAttribute}\" fired"); };
        }

        private void Update()
        {
            if (Keyboard.current.tKey.wasPressedThisFrame)
            {
                OnEventHappened?.Invoke();
            }

            if (Keyboard.current.sKey.wasPressedThisFrame)
            {
                OnEventWithStringAttributeHappened?.Invoke("I can be any type!");
            }
            
            if (Keyboard.current.iKey.wasPressedThisFrame)
            {
                Player.Instance.FadeIn(1f, false);
            }

            if (Keyboard.current.oKey.wasPressedThisFrame)
            {
                Player.Instance.FadeOut(1f, false);
            }
        }

        [AosAction("Do magic void")]
        public void DoMagic(bool first, int second, string third)
        {
            Debug.Log($"first = {first}, second = {second}, third = {third}");
        }

        [AosAction("Non-void action")]
        public bool NonVoidAction()
        {
            return true;
        }
        
        [AosAction("Json parameters")]
        public void JsonTest(JObject data1, JArray data2)
        {
            Debug.Log(data1.SelectToken("name"));
            Debug.Log(data2.SelectToken("[0].data_pan.position"));
        }

        private bool _grabbed;

        public void OnClicked(InteractHand interactHand)
        {
            Debug.Log($"{gameObject.name} clicked");

            if (!_grabbed)
            {
                Player.Instance.GrabObject("Wrench", 0);
                _grabbed = true;
            }
            else
            {
                Player.Instance.DropObject(0);
                _grabbed = false;
            }
        }

        public bool IsClickable { get; set; } = true;
        public bool IsHoverable { get; set; } = true;

        public void OnHoverIn(InteractHand interactHand)
        {
            GetComponent<Renderer>().material.color /= 2;
        }

        public void OnHoverOut(InteractHand interactHand)
        {
            GetComponent<Renderer>().material.color *= 2;
        }
    }
}