using UnityEngine;

public class ZonaDestroy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Nota")) return;

        if (MiniJuegoManager.Instance != null)
            MiniJuegoManager.Instance.Incorrecto();

        Destroy(other.gameObject);
    }
}