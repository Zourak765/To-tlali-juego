using UnityEngine;

public class NotaElim : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);
    }

    // 🔥 ESTE ES EL QUE TE FALTABA
    public void Acierto()
    {
        Debug.Log("✔ Nota acertada");

        if (MiniJuegoManager.Instance != null)
            MiniJuegoManager.Instance.Correcto();

        Destroy(gameObject);
    }
}