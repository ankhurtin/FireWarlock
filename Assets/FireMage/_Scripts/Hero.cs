using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
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

        public void CastBall() {
            if (ballPrefab == null) return;
            var startPosition = _aimPoint.transform.position;
            var forceBall = _aim.GetDir() * hitForce;

            if (_ballInstance == null || _ballInstance.IsDestroyed()) {
                _ballInstance = Instantiate(ballPrefab);
                var ball = _ballInstance.GetComponent<Ball>();
                ball.Hit(startPosition, forceBall);
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
