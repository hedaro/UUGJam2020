using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MultiGameJam
{
    [CreateAssetMenu(fileName = "Navigation", menuName = "Navigation")]
    public class NavigationData : ScriptableObject
    {
        public float timePerGame;
        public string loadScreenSceneName;
        public GameObject loadLayout;
        public GameCollection gameCollection;

    }
}
