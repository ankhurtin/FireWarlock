using UnityEngine;
using UnityEngine.SceneManagement;

namespace FireMage._Scripts.Utility {
    public class UIController : MonoBehaviour {
        [SerializeField] private Canvas uiWinner;
        public void StartGame() {
            SceneManager.LoadScene("SampleScene");
        }

        public void ExitGame() {
            Application.Quit();
        }

        public void ReloadLevel() {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        public void GoToMainMenu() {
            SceneManager.LoadScene("Intro");
        }

        public void CompletedLevel() {
            uiWinner.gameObject.SetActive(true);
        }
    }
}
