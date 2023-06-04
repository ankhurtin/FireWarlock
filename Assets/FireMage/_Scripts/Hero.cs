using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace FireMage._Scripts {
    public class Hero : MonoBehaviour {
        [SerializeField] private float speed = 3f;
        [SerializeField] private GameObject ballPrefab;
        [SerializeField] private float hitForce;
        private float _direction;
        private Animator _animator;
        private bool _isFlip;
        private GameObject _spriteWrapper;
        private Aim _aim;
        private GameObject _aimPoint;
        private GameObject _ballInstance;
        private float _pressedCastInputTime;

        private static readonly int IsRunning = Animator.StringToHash("IsRunning");

        private void Awake() {
            _animator = GetComponentInChildren<Animator>();
            _spriteWrapper = GameObject.FindGameObjectWithTag("MageSpriteWrapper");
            _aim = GetComponentInChildren<Aim>();
            _aimPoint = GameObject.FindGameObjectWithTag("AimPoint");
        }

        private void Update() {
            Movement(_direction);
        }

        public void SetDirection(float direction) {
            _direction = direction;
        }

        private void Movement(float direction) {
            if (direction != 0) {
                transform.Translate(Vector3.right * (speed * direction * Time.deltaTime));
            }
            
            FlipX();
        }

        public void CastBall(InputAction.CallbackContext context) {
            if (ballPrefab == null) return;
            if (_pressedCastInputTime == 0) _pressedCastInputTime = Time.time;
            if ((_ballInstance == null || _ballInstance.IsDestroyed()) && context.canceled) {
                var time = Time.time - _pressedCastInputTime;
                var forceMultiplier = (float)(time >= 3 ? 3 : time) / 3;
                var angle = _aim.GetAngle();
                var x = Mathf.Cos(angle * Mathf.PI / 180) * hitForce * forceMultiplier;
                var y = Mathf.Sin(angle * Mathf.PI / 180) * hitForce * forceMultiplier;
                var startPosition = _aimPoint.transform.position;
                var forceBall = new Vector2(x, y);
                
                _ballInstance = Instantiate(ballPrefab);
                var ball = _ballInstance.GetComponent<Ball>();
                ball.Hit(startPosition, forceBall);

                _pressedCastInputTime = 0;
            }
        }
        
        private void FlipX() {
            var direction = _aim.GetAngle();
            if (_isFlip == direction < 0f) return;

            _spriteWrapper.transform.Rotate(new Vector3(0, 180, 0));
            _isFlip = direction < 0f;
        }
    }
}
