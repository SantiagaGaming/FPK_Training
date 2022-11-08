using System.Collections;
using UnityEngine;

namespace AosSdk.Core.Utils
{
    public class FadeController : MonoBehaviour
    {
        [SerializeField] private Renderer _fadeScreen;

        private Color _currentColor = new Color(0, 0, 0, 0);

        private float _fadeValue;

        public void Fade(float targetAlpha, float speed = 5f, bool isInstant = false)
        {
            _fadeValue = isInstant ? targetAlpha : Mathf.MoveTowards(_currentColor.a, targetAlpha, Time.fixedDeltaTime * speed);

            var material = _fadeScreen.material;

            _currentColor = material.color;
            _currentColor.a = _fadeValue;
            material.color = _currentColor;
        }

        public IEnumerator FadeIn(float speed, bool isInstant)
        {
            const int target = 1;
            while (_fadeValue < target)
            {
                Fade(target, speed, isInstant);
                yield return null;
            }
        }

        public IEnumerator FadeOut(float speed, bool isInstant)
        {
            const int target = 0;
            while (_fadeValue > target)
            {
                Fade(target, speed, isInstant);
                yield return null;
            }
        }
    }
}