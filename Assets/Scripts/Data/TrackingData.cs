using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MultiGameJam
{
    [CreateAssetMenu(fileName = "Tracking", menuName = "TrackingData")]
    public class TrackingData : ScriptableObject
    {
        public GameCollection gameCollection;
        public int highScore;
    }
}