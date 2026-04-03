using UnityEngine;

public class ObjetoColect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventMenu.instancia.AgregarObjeto(gameObject.tag);
            Destroy(gameObject);
        }
    }
}