using System;
using System.Linq;
using UnityEngine;

namespace FireMage._Scripts.Utility {
    public class CheckVictory : MonoBehaviour {
        [SerializeField] private Torch[] torches;
        

        private bool IsVictory() {
            var count = torches.Count(t => t.IsActive());
            return count == torches.Length;
        }
    }
}
