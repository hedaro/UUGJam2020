using MultiGameJam;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BigJump
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : MonoBehaviour
    {
        protected new Rigidbody2D rigidbody;

        IEnumerator Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.simulated = false;

            yield return new WaitForSeconds(1.333f);

            GameManager.GameLoaded();
            rigidbody.simulated = true;

            yield return new WaitForSeconds(0.333f);
            GameManager.AddPoints(10);

            yield return new WaitForSeconds(10.333f);
            GameManager.DamagePlayer();
            GameManager.DamagePlayer();
            GameManager.DamagePlayer();
        }

    }
}
