using UnityEngine;

public class Carro : MonoBehaviour
{
    public Transform destino;
    public float velocidad = 5f;

    private Rigidbody2D rb;
    private float direccion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        direccion = Mathf.Sign(destino.position.x - transform.position.x);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direccion * velocidad, 0f);
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