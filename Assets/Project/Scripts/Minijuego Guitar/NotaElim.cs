using UnityEngine;

public class NotaElim : MonoBehaviour
{
    public float velocidad = 6f;
    public MiniJuegoManager miniJuegoManager; 

    void Update()
    {
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);

        if (transform.position.y < -5f) 
        {
            if (miniJuegoManager != null)
                miniJuegoManager.NotaIncorrecta();
            Destroy(gameObject);
        }
    }

    public void Acierto()
    {
        if (miniJuegoManager != null)
            miniJuegoManager.NotaCorrecta();
        Destroy(gameObject);
    }
}