using UnityEngine;

public class ObjetoColect : MonoBehaviour
{
    public bool esAcumulable = false;
    public AudioClip sonido;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (sonido != null)
            {
                AudioSource.PlayClipAtPoint(sonido, transform.position);
            }

            InventMenu.instancia.AgregarObjeto(gameObject.tag, esAcumulable);
            Destroy(gameObject);
        }
    }
}