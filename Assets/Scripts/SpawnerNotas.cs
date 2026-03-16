using UnityEngine;

public class SpawnerNotas : MonoBehaviour
{
    public GameObject notaPrefab;

    public Transform linea1;
    public Transform linea2;
    public Transform linea3;

    public AudioSource musica;

    float[] espectro = new float[64];

    public float sensibilidad = 0.02f;

    public float tiempoEntreNotas = 0.35f;
    float temporizador;

    int ultimaLinea = 0;
    int contadorRepetidas = 0;

    void Update()
    {
        temporizador += Time.deltaTime;

        musica.GetSpectrumData(espectro, 0, FFTWindow.Rectangular);

        if (espectro[5] > sensibilidad && temporizador >= tiempoEntreNotas)
        {
            int linea = Random.Range(1, 4);

            if (linea == ultimaLinea)
            {
                contadorRepetidas++;
            }
            else
            {
                contadorRepetidas = 0;
            }

            if (contadorRepetidas >= 2)
            {
                while (linea == ultimaLinea)
                {
                    linea = Random.Range(1, 4);
                }

                contadorRepetidas = 0;
            }

            if (linea == 1)
                Instantiate(notaPrefab, linea1.position, Quaternion.identity);

            if (linea == 2)
                Instantiate(notaPrefab, linea2.position, Quaternion.identity);

            if (linea == 3)
                Instantiate(notaPrefab, linea3.position, Quaternion.identity);

            ultimaLinea = linea;
            temporizador = 0f;
        }
    }
}