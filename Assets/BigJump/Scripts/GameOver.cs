using MultiGameJam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigJump
{
    public class GameOver : MonoBehaviour
    {
        IEnumerator Start()
        {
            yield return new WaitForSeconds(1.333f);

            GameManager.GameLoaded();

            yield return new WaitForSeconds(1.333f);
            GameManager.DamagePlayer();
        }
    }
}
