using UnityEngine;

public class DestroyCars : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Destino"))
        {
            Destroy(gameObject);
        }
    }
}