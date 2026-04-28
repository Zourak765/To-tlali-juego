using UnityEngine;

public class ZonaHit : MonoBehaviour
{
    public string tagNota;

    private GameObject notaEnZona;

    public MiniJuegoManager manager;

    void OnMouseDown()
    {
        if (manager != null && manager.juegoTerminado) return;

        Presionar();
    }

    public void Presionar()
    {
        if (notaEnZona != null)
        {
            Debug.Log("ACIERTO");

            if (manager != null)
                manager.NotaCorrecta();

            Destroy(notaEnZona);
            notaEnZona = null;
        }
        else
        {
            Debug.Log("FALLO");

            if (manager != null)
                manager.NotaIncorrecta();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagNota))
        {
            notaEnZona = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(tagNota))
        {
            if (other.gameObject == notaEnZona)
                notaEnZona = null;
        }
    }
}