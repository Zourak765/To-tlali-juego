using UnityEngine;

public class NotaMov : MonoBehaviour
{
    public float velocidad = 6f;

    void Update()
    {
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);
    }
}