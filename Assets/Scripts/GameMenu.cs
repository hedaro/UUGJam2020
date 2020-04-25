using MultiGameJam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MultiGameJam
{
    public class GameMenu : MonoBehaviour
    {
        public string submitButton;

        void Update()
        {
            if (Input.GetButtonDown(submitButton))
            {
                GameManager.StartGame();
            }
        }
    }
}
