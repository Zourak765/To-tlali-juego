using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class ZonaDestroy : MonoBehaviour
{
    public string tagNota;
    public string tagNota2;
    public MiniJuegoManager manager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagNota))
        {
            manager.NotaIncorrecta();

            Destroy(other.gameObject);
        }
        
        if (other.CompareTag(tagNota2))
        {
            manager.NotaIncorrecta();

            Destroy(other.gameObject);
        }
    }
}
