using UnityEngine;
using UnityEngine.InputSystem;

namespace FireMage._Scripts {
    public class HeroInputReader : MonoBehaviour {
        [SerializeField] private Hero hero;
        public void OnHorizontalMovement(InputAction.CallbackContext context) {
            var direction = context.ReadValue<float>();
            hero.SetDirection(direction);
        }
        
        public void OnCastBall(InputAction.CallbackContext context) {
            hero.CastBall(context);
        }
    }
}
