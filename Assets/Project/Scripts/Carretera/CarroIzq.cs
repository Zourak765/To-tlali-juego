using UnityEngine;

public class CarroIzquierda : MonoBehaviour
{
    public float velocidad = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            sr.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(-velocidad, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destino"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInicio player = collision.gameObject.GetComponent<PlayerInicio>();

            if (player != null)
            {
                player.RegresarAlInicio();
            }
        }
    }
}