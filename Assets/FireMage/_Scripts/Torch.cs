using System;
using UnityEngine;

namespace FireMage._Scripts {
    public class Torch : MonoBehaviour {
        private Light _light;
        private bool _isActive;

        private void Awake() {
            _light = GetComponentInChildren<Light>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (_light.intensity == 0) {
                _light.intensity = 30;
                _isActive = true;
            }
        }

        public bool IsActive() {
            return _isActive;
        }
    }
}
