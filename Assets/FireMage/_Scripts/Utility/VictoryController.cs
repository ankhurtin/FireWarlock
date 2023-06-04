using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FireMage._Scripts.Utility {
    public class VictoryController : MonoBehaviour {
        [SerializeField] private GameElementsState gameElementsState;

        public bool IsVictory() {
            return gameElementsState.CountOfActiveTorches() == gameElementsState.CountOfTorches();
        }
    }
}
