using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FireMage._Scripts.Utility {
    public static class LevelManager {
        public static void FinishLevel() {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
