using UnityEngine;
using UnityEngine.InputSystem;

public class ZonaHit : MonoBehaviour
{
    private GameObject notaEnZona;

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.aKey.wasPressedThisFrame ||
            Keyboard.current.dKey.wasPressedThisFrame)
        {
            Presionar();
        }
    }

    void Presionar()
    {
        if (notaEnZona != null)
        {

            notaEnZona.GetComponent<NotaElim>().Acierto();
            notaEnZona = null;
        }
        else
        {

            if (MiniJuegoManager.Instance != null)
                MiniJuegoManager.Instance.Incorrecto();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nota"))
        {
            notaEnZona = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == notaEnZona)
        {
            notaEnZona = null;
        }
    }
}