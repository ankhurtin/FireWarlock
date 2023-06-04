using System;
using System.Collections;
using FireMage._Scripts.Utility;
using UnityEngine;

namespace FireMage._Scripts {
    public class Ball : MonoBehaviour {
        [SerializeField] private GameObject explosionPrefab;
        private Rigidbody2D _rigidBody;
        private bool _isRunning;
        private GameObject _explosionInstance;
        private SpriteRenderer _sprite;
        private ParticleSystem _fireEffect;
        private Light _lightEffect;
        private VictoryController _victoryController;
        private GameElementsState _gameElementsState;
        private UIController _uiController;

        private void Awake() {
            _rigidBody = GetComponent<Rigidbody2D>();
            _sprite = GetComponentInChildren<SpriteRenderer>();
            _fireEffect = GetComponentInChildren<ParticleSystem>();
            _lightEffect = GetComponentInChildren<Light>();
            _victoryController = FindObjectOfType<VictoryController>();
            _gameElementsState = FindObjectOfType<GameElementsState>();
            _uiController = FindObjectOfType<UIController>();

        }

        private void FixedUpdate() {
            WatchIsOver();
        }

        private void OnCollisionEnter2D(Collision2D other) {
            var hero = other.gameObject.GetComponent<Hero>();

            if (hero != null) {
                StartCoroutine(DestroyBall());
            }
        }

        public void Hit(Vector3 startPosition, Vector2 force) {
            if (!_isRunning) {
                transform.position = startPosition;
                _rigidBody.AddForce(force, ForceMode2D.Impulse);
                _isRunning = true;
            }
        }

        private void WatchIsOver() {
            var speed = Vector3.Magnitude(_rigidBody.velocity);
            if (speed < 2f) {
                StartCoroutine(DestroyBall());
            }
        }

        private IEnumerator DestroyBall() {
            _isRunning = false;
            if (!_explosionInstance) {
                _explosionInstance = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(_explosionInstance, 0.5f);
                _sprite.gameObject.SetActive(false);
                _fireEffect.gameObject.SetActive(false);
                _lightEffect.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                CheckVictory();
                Destroy(gameObject);
            }
        }

        private void CheckVictory() {
            if (_victoryController.IsVictory()) {
                _uiController.CompletedLevel();
            }
            else {
                _gameElementsState.ResetState();
            }
        }
    }
}
