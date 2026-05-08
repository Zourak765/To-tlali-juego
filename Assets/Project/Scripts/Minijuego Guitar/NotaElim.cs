using UnityEngine;

public class NotaElim : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);
    }

    public void Acierto()
    {

        if (MiniJuegoManager.Instance != null)
            MiniJuegoManager.Instance.Correcto();

        Destroy(gameObject);
    }
}