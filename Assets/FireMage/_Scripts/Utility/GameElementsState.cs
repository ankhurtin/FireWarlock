using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FireMage._Scripts {
    public class GameElementsState : MonoBehaviour {
        private List<Torch> _torches;
        private void Awake() {
            var torches = FindObjectsOfType<Torch>();
            _torches = torches.ToList();
        }

        public int CountOfActiveTorches() {
            return _torches.Count(torch => torch.IsActiveTorch());
        }

        public int CountOfTorches() {
            return _torches.Count;
        }

        public void ResetState() {
            _torches.ForEach((e) => e.SetNotActiveTorch());
        }
    }
}
