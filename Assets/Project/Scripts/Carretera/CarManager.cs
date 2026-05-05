using UnityEngine;
using System.Collections.Generic;

public class CarManager : MonoBehaviour
{
    [Header("Para la Derecha")]
    public List<GameObject> carrosDerecha;

    [Header("Para la Izquierda")]
    public List<GameObject> carrosIzquierda;

    public float velocidad = 5f;

    void Start()
    {
        foreach (GameObject carro in carrosDerecha)
        {
            ConfigurarCarro(carro, 1);
        }

        foreach (GameObject carro in carrosIzquierda)
        {
            ConfigurarCarro(carro, -1);
        }
    }

    void ConfigurarCarro(GameObject carro, int direccion)
    {
        Rigidbody2D rb = carro.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = new Vector2(direccion * velocidad, 0f);
        }

        if (direccion == -1)
        {
            Vector3 escala = carro.transform.localScale;
            escala.x *= -1;
            carro.transform.localScale = escala;
        }
    }
}