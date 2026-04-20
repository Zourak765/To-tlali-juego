using UnityEngine;

public class SpawnerNotas : MonoBehaviour
{
    public GameObject notaNaranja;
    public GameObject notaAzul;

    public Transform lineaIzquierda;
    public Transform lineaDerecha;

    public MiniJuegoManager miniJuegoManager; // referencia local al manager de esta estatua

    float[] espectro = new float[64];
    public float sensibilidad = 0.02f;

    public float tiempoEntreNotas = 0.35f;
    float temporizador;

    int ultimaLinea = 0;
    int contadorRepetidas = 0;

    void Update()
    {
        if (miniJuegoManager == null || miniJuegoManager.musica == null || miniJuegoManager.juegoTerminado)
            return;

        temporizador += Time.deltaTime;

        miniJuegoManager.musica.GetSpectrumData(espectro, 0, FFTWindow.Rectangular);

        if (espectro[5] > sensibilidad && temporizador >= tiempoEntreNotas)
        {
            int linea = Random.Range(1, 3);

            if (linea == ultimaLinea)
                contadorRepetidas++;
            else
                contadorRepetidas = 0;

            if (contadorRepetidas >= 2)
            {
                linea = (linea == 1) ? 2 : 1;
                contadorRepetidas = 0;
            }

            if (linea == 1)
                Instantiate(notaNaranja, lineaIzquierda.position, Quaternion.identity);

            if (linea == 2)
                Instantiate(notaAzul, lineaDerecha.position, Quaternion.identity);

            ultimaLinea = linea;
            temporizador = 0f;
        }
    }
}