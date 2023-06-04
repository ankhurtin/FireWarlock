using System;
using UnityEngine;

namespace FireMage._Scripts {
    public class Aim : MonoBehaviour {
        [SerializeField] private Transform aim;

        private Vector3 _aimDir;
        private float _angle;
        private void Update() {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            
            _aimDir = (mousePosition - transform.position).normalized;
            _angle = Mathf.Atan2(_aimDir.x, _aimDir.y) * Mathf.Rad2Deg;

            aim.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -_angle));
        }

        public Vector3 GetDir() {
            return _aimDir;
        }

        public float GetAngle() {
            return _angle;
        }
    }
}
