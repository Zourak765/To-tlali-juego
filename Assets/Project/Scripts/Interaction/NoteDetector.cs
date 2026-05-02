using UnityEngine;
using UnityEngine.InputSystem;

public class NoteDetector : MonoBehaviour
{
    public bool esLineaIzquierda;
    public bool esLineaDerecha;

    private GameObject notaActual;

    void Update()
    {
        if (Keyboard.current == null) return;
        if (MiniJuegoManager.Instance == null) return;

        // 🔥 DEBUG CLAVE
        if (notaActual != null)
            Debug.Log("🎯 Nota en zona: " + notaActual.name);

        if (notaActual == null) return;

        if (esLineaIzquierda && Keyboard.current.aKey.wasPressedThisFrame)
        {
            Hit();
        }

        if (esLineaDerecha && Keyboard.current.dKey.wasPressedThisFrame)
        {
            Hit();
        }
    }

    void Hit()
    {
        Debug.Log("✔ HIT REAL");

        if (notaActual != null)
        {
            notaActual.GetComponent<NotaElim>().Acierto();
            notaActual = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("📥 Trigger enter: " + other.name);

        if (!other.CompareTag("Nota"))
        {
            Debug.Log("❌ NO ES NOTA (tag incorrecto)");
            return;
        }

        notaActual = other.gameObject;
        Debug.Log("🎯 Nota registrada en zona");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (notaActual == other.gameObject)
        {
            Debug.Log("❌ Nota salió de zona");
            notaActual = null;
        }
    }
}