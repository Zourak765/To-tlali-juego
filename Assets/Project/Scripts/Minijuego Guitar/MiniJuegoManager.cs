using UnityEngine;
using UnityEngine.UI;

public class MiniJuegoManager : MonoBehaviour
{
    public Slider barra;
    public GameObject canvasMinijuego;
    public float progreso = 0f;
    public float maxProgreso = 100f;
    public bool juegoTerminado = false;
    public bool gano = false;
    public AudioSource musica;

    bool musicaInicio = false;

    public void IniciarMinijuego(AudioClip nuevaMusica, GameObject canvas)
    {
        canvasMinijuego = canvas;
        canvasMinijuego.SetActive(true);

        progreso = 0f;
        juegoTerminado = false;
        gano = false;
        barra.value = 0;

        musica.Stop();
        musica.clip = nuevaMusica;
        musica.Play();
        musicaInicio = true;
    }

    void Update()
    {
        barra.value = progreso;

        if (musicaInicio && !musica.isPlaying && !juegoTerminado)
        {
            TerminarJuego();
        }

        if (!juegoTerminado && progreso >= maxProgreso)
        {
            progreso = maxProgreso;
        }
    }

    public void NotaCorrecta()
    {
        progreso += 10f;
        progreso = Mathf.Clamp(progreso, 0, maxProgreso);
    }

    public void NotaIncorrecta()
    {
        progreso -= 15f;
        progreso = Mathf.Clamp(progreso, 0, maxProgreso);
    }

    void TerminarJuego()
    {
        juegoTerminado = true;
        gano = (progreso >= maxProgreso);
        musica.Stop();
    }
}