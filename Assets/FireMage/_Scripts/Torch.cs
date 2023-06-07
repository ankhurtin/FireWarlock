using System;
using FireMage._Scripts.Utility;
using UnityEngine;
using UnityEngine.Serialization;

namespace FireMage._Scripts {
    public class Torch : MonoBehaviour {
        private Light _light;
        private bool _isActive;
        private AudioSource _enableAudio;

        private void Awake() {
            _light = GetComponentInChildren<Light>();
            _enableAudio = GetComponentInChildren<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (!_isActive) {
                SetActiveTorch();
            }
        }

        public bool IsActiveTorch() {
            return _isActive;
        }

        public void SetActiveTorch() {
            _enableAudio.Play();
            _light.intensity = 30;
            _isActive = true;
        }

        public void SetNotActiveTorch() {
            _light.intensity = 0;
            _isActive = false;
        }
    }
}
