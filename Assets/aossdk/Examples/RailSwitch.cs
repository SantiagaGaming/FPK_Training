using AosSdk.Core.Utils;
using UnityEngine;

namespace AosSdk.Examples
{
    [AosObject("Привод стрелки 5")]
    public class RailSwitch : AosObjectBase
    {
        [SerializeField] private SwitchCap switchCap;
    
        [AosAction("Перевести стрелку")]
        public void Switch([AosParameter("Направление перевода")] int direction)
        {
        
        }

        [AosEvent("При открытии крышки привода")]
        public event AosEventHandler OnCapOpened;

        private void Start()
        {
            switchCap.OnCapOpened += CapOpened;
        }

        private void CapOpened()
        {
            OnCapOpened?.Invoke();
        }
    }
}
