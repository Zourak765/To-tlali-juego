using UnityEngine;

public class NotaElim : MonoBehaviour
{
    public float velocidad = 6f;
    void Update()
    {
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);
    }
    /*public void Acierto()
    {
        MiniJuegoManager.instancia.NotaCorrecta();
        print("hola");
        Destroy(gameObject);
    }

    public void Fallo()
    {
        MiniJuegoManager.instancia.NotaIncorrecta();
        Destroy(gameObject);
    }*/
}