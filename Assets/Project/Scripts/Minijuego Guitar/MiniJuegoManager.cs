using UnityEngine;
using UnityEngine.UI;

public class MiniJuegoManager : MonoBehaviour
{
    public static MiniJuegoManager instancia;

    public Slider barra;
    public GameObject canvasMinijuego;

    public float progreso = 0f;
    public float maxProgreso = 100f;

    public bool juegoTerminado = false;
    public bool gano = false;

    public AudioSource musica;

    bool musicaInicio = false;

    void Awake()
    {
        instancia = this;
    }

    void Update()
    {
        barra.value = progreso;

        if (musicaInicio && !musica.isPlaying && !juegoTerminado)
        {
            TerminarJuego();
        }
    }

    public void IniciarMinijuego(AudioClip nuevaMusica)
    {
        canvasMinijuego.SetActive(true);

        progreso = 0f;
        juegoTerminado = false;
        gano = false;

        barra.value = 0;

        musica.Stop();
        musicaInicio = false;

        if (nuevaMusica != null)
        {
            musica.clip = nuevaMusica;
        }

        Invoke("IniciarMusica", 2f);
    }

    void IniciarMusica()
    {
        musica.Play();
        musicaInicio = true;
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
    }
}