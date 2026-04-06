using UnityEngine;

public class Carro : MonoBehaviour
{
    public float velocidad = 5f;

    [HideInInspector]
    public Transform destino;

    public Transform puntoInicioJugador;

    void Update()
    {
        if (destino != null)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                destino.position,
                velocidad * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, destino.position) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Choque con: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("ES EL PLAYER");

            other.transform.position = puntoInicioJugador.position;
        }
    }
}