using UnityEngine;

public class ZonaDestroy : MonoBehaviour
{
    public MiniJuegoManager miniJuegoManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Nota")) return;

        if (miniJuegoManager != null)
            miniJuegoManager.NotaIncorrecta();

        Destroy(other.gameObject);
    }
}