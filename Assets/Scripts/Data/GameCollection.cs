using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MultiGameJam
{
    [System.Serializable]
    public class GameData
    {
        public string name;
        public int id;
        public string baseScene;
        public int livesSpent;
        public int wins;
    }

    [CreateAssetMenu(fileName = "Games/Collection", menuName = "GameCollection")]
    public class GameCollection : ScriptableObject
    {
        public List<GameData> games;
    }
}


