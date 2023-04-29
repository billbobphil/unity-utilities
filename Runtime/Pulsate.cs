using System;
using UnityEngine;

namespace Utilities
{
    public class Pulsate : MonoBehaviour
    {
        public Vector3 maxScale;
        public Vector3 minScale;
        public float scaleIncrement;
        private bool _isGrowing = true;
        private Vector3 _originalScale;
        public bool useTimeScale;

        private void Start()
        {
            _originalScale = transform.localScale;
        }
        
        private void Update() {
            if(useTimeScale) return;

            DetermineIsGrowing();

            if (_isGrowing)
            {
                transform.localScale += new Vector3(scaleIncrement * Time.unscaledDeltaTime, scaleIncrement * Time.unscaledDeltaTime, 0);
            }
            else
            {
                transform.localScale -= new Vector3(scaleIncrement * Time.unscaledDeltaTime, scaleIncrement * Time.unscaledDeltaTime, 0);
            }
        }
        
        private void FixedUpdate()
        {
            if(!useTimeScale) return;

            DetermineIsGrowing();

            if (_isGrowing)
            {
                transform.localScale += new Vector3(scaleIncrement,scaleIncrement, 0);
            }
            else
            {
                transform.localScale -= new Vector3(scaleIncrement, scaleIncrement, 0);
            }
        }

        private void DetermineIsGrowing() {
            if (transform.localScale.x >= maxScale.x && transform.localScale.y >= maxScale.y)
            {
                _isGrowing = false;
            }
            else if (transform.localScale.x <= minScale.x && transform.localScale.y <= minScale.y)
            {
                _isGrowing = true;
            }
        }

        private void OnDisable()
        {
            transform.localScale = _originalScale;
        }
    }
}
