using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cutscenes
{
    [System.Serializable]

    public class CutsceneMovement
    {
        [Tooltip("Vector3 to move to.")]
        [Rename("Vector3:")]
        public Vector3 move;

        [Space(10)]

        [Tooltip("Duration of movement.")]
        [Rename("Duration (seconds):")]
        public float duration;

        [Space(10)]

        [Tooltip("0: Linear, 1: Smoothstep, 2: Ease In, 3: Ease Out")]
        [Rename("Smoothing Type:")]
        public int smoothing;
    }
}

