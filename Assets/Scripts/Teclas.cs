using UnityEngine;

public class Teclas : MonoBehaviour
{
    public int tipoTecla; 

    GameObject notaDentro;

    void Update()
    {
        if (notaDentro != null)
        {
            if (tipoTecla == 1 && Input.GetKeyDown(KeyCode.A))
            {
                Destroy(notaDentro);
            }

            if (tipoTecla == 2 && Input.GetKeyDown(KeyCode.S))
            {
                Destroy(notaDentro);
            }

            if (tipoTecla == 3 && Input.GetKeyDown(KeyCode.D))
            {
                Destroy(notaDentro);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nota"))
        {
            notaDentro = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Nota"))
        {
            notaDentro = null;
        }
    }
}