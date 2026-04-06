using UnityEngine;

public class ObjetoColect : MonoBehaviour
{
    public bool esAcumulable = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventMenu.instancia.AgregarObjeto(gameObject.tag, esAcumulable);
            Destroy(gameObject);
        }
    }
}