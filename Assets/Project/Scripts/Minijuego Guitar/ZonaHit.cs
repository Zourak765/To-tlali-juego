using UnityEngine;

public class ZonaHit : MonoBehaviour
{
    public KeyCode tecla;
    public string tagNota;

    private GameObject notaEnZona;

    public MiniJuegoManager manager;

    void Update()
    {
        if (Input.GetKeyDown(tecla))
        {
            if (notaEnZona != null)
            {
                Debug.Log("ACIERTO");

                manager.NotaCorrecta();

                Destroy(notaEnZona);
                notaEnZona = null;
            }
            else
            {
                Debug.Log("FALLO");

                manager.NotaIncorrecta();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag(tagNota))
        {
            notaEnZona = other.gameObject;
        }
    }
}