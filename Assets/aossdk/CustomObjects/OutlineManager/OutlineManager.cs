using AosSdk.Core.Utils;
using AosSdk.ThirdParty.QuickOutline.Scripts;
using UnityEngine;

namespace AosSdk.CustomObjects.OutlineManager
{
    [AosObject("Менеджер выделения")]
    public class OutlineManager : AosObjectBase
    {
        private Color _defaultOutlineColor = Color.green;
        private float _defaultOutlineWidth = 5f;
        private OutlineMode _defaultOutlineMode = OutlineMode.OutlineAll;

        [AosAction("Выделить объект")]
        public void OutlineObjectWithParameters([AosParameter("guid объекта")] string objectGuid, [AosParameter("r - компонента цвета [0...255]")] float red,
            [AosParameter("g - компонента цвета [0...255]")]
            float green, [AosParameter("b - компонента цвета [0...255]")] float blue, [AosParameter("толщина выделения")] float width,
            [AosParameter("режим выделения")] OutlineMode mode)
        {
            var aosObjectToOutline = AosObjectFind.FindAosObjectById(objectGuid);

            if (!aosObjectToOutline)
            {
                ReportError($"HighlightObject: Object with guid = {objectGuid} not found");
                return;
            }

            OutlineObject(aosObjectToOutline.gameObject, red, green, blue, width, mode);
        }

        [AosAction("Выделить объект со стандартными настройками выделения")]
        public void OutlineObjectWithDefaultParameters(string objectGuid)
        {
            var aosObjectToOutline = AosObjectFind.FindAosObjectById(objectGuid);

            if (!aosObjectToOutline)
            {
                ReportError($"OutlineObjectWithDefaultParameters: Object with guid = {objectGuid} not found");
                return;
            }

            OutlineObject(aosObjectToOutline.gameObject, _defaultOutlineColor.r, _defaultOutlineColor.g, _defaultOutlineColor.b, _defaultOutlineWidth, _defaultOutlineMode);
        }

        [AosAction("Установить стандартные настройки выделения")]
        public void SetOutlineDefaultParameters([AosParameter("r - компонента цвета [0...255]")] float red, [AosParameter("g - компонента цвета [0...255]")] float green,
            [AosParameter("b - компонента цвета [0...255]")]
            float blue, [AosParameter("толщина выделения")] float width,
            [AosParameter("режим выделения")] OutlineMode mode)
        {
            _defaultOutlineColor = new Color(red, green, blue, 255);
            _defaultOutlineWidth = width;
            _defaultOutlineMode = mode;
        }

        [AosAction("Убрать выделение с объекта")]
        public void DisableOutline([AosParameter("guid объекта")] string objectGuid)
        {
            var aosObjectToHighlight = AosObjectFind.FindAosObjectById(objectGuid);

            if (!aosObjectToHighlight)
            {
                ReportError($"DisableOutline: Object with guid = {objectGuid} not found");
                return;
            }

            var outlineComponent = aosObjectToHighlight.GetComponent<Outline>();

            if (!outlineComponent)
            {
                ReportError($"DisableOutline: Object with guid = {objectGuid} has no outline on it");
                return;
            }

            outlineComponent.enabled = false;
        }

        private static void OutlineObject(GameObject aosObjectToOutline, float red, float green, float blue, float width, OutlineMode mode)
        {
            var outlineComponent = aosObjectToOutline.GetComponent<Outline>();

            if (outlineComponent == null)
            {
                outlineComponent = aosObjectToOutline.AddComponent<Outline>();
                outlineComponent.enabled = false;
            }

            outlineComponent.OutlineColor = new Color(red, green, blue, 255);
            outlineComponent.OutlineWidth = width;
            outlineComponent.OutlineOutlineMode = mode;

            outlineComponent.enabled = true;
        }
    }
}