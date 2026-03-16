using UnityEngine;

public class IntePer : MonoBehaviour
{
    public GameObject canvas;
    public float tiempoVisible = 3f;

    float temporizador;
    bool mensajeActivo;

    void Update()
    {
        if (mensajeActivo)
        {
            temporizador += Time.deltaTime;

            if (temporizador >= tiempoVisible)
            {
                canvas.SetActive(false);
                mensajeActivo = false;
                temporizador = 0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(true);
            mensajeActivo = true;
            temporizador = 0f;
        }
    }
}