using UnityEngine;

public class SFXItem : MonoBehaviour
{
    public AudioClip[] sonidos;   
    public bool RandomSound = true; 
    public int indiceSonido = 0;  
    public float volumen = 1f;

    private bool recogido = false;

    void OnTriggerEnter(Collider other)
    {
        if (recogido) return;

        if (other.CompareTag("Player"))
        {
            recogido = true;

            AudioClip sonidoAUsar = null;

            if (sonidos.Length > 0)
            {
                if (RandomSound)
                {
                    int index = Random.Range(0, sonidos.Length);
                    sonidoAUsar = sonidos[index];
                }
                else
                {
                    indiceSonido = Mathf.Clamp(indiceSonido, 0, sonidos.Length - 1);
                    sonidoAUsar = sonidos[indiceSonido];
                }
            }

            if (sonidoAUsar != null)
            {
                AudioSource.PlayClipAtPoint(sonidoAUsar, transform.position, volumen);
            }

            Destroy(gameObject);
        }
    }
}
