using System.Collections;
using UnityEngine;

public class Teletransporte: MonoBehaviour
{
    public Transform destino;
    public float tiempoEspera = 1f;
    public float tiempoBloqueo = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerTeleport pt = other.GetComponent<PlayerTeleport>();

            if (pt != null)
            {
                if (pt.puedeTeletransportarse == true)
                {
                    StartCoroutine(Teleport(other, pt));
                }
            }
        }
    }

    IEnumerator Teleport(Collider2D player, PlayerTeleport pt)
    {
        pt.puedeTeletransportarse = false;

        FadeController fade = FindFirstObjectByType<FadeController>();

        if (fade != null)
        {
            fade.FadeNegro();
        }

        yield return new WaitForSeconds(tiempoEspera);

        player.transform.position = destino.position;

        if (fade != null)
        {
            fade.QuitarNegro();
        }

        yield return new WaitForSeconds(tiempoBloqueo);

        pt.puedeTeletransportarse = true;
    }
}