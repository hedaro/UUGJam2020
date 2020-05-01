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

            
            /*
             * El juegos ha cargado por completo y esta listo para jugar
             */
            GameManager.GameLoaded();

            rigidbody.simulated = true;

            yield return new WaitForSeconds(0.333f);


            /*
             * El jugador ha obtenido puntos para su puntuacion final
             * No hay limite de cuantos puntos otorgar, pero no hay que ser injustos dando demas o cada segundo
             */
            GameManager.AddPoints(10);

            yield return new WaitForSeconds(10.333f);

            /*
             * Quitarle 1 corazon de vida al jugador, por ejemplo cuando choque con un enemigo
             * No hay limite de cuantos corazones quitar por juego, pero no hay que ser injustos
             */
            GameManager.DamagePlayer();



            GameManager.DamagePlayer();
            GameManager.DamagePlayer();
        }

    }
}
