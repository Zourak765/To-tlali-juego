using UnityEngine;
using UnityEngine.UI;

public class MiniJuegoManager : MonoBehaviour
{
    public static MiniJuegoManager Instance;

    [Header("UI")]
    public Slider barra;
    public GameObject canvasMinijuego;

    [Header("Progreso")]
    public float progreso = 0f;
    public float maxProgreso = 100f;

    [Header("Estado")]
    public bool juegoTerminado = false;
    public bool gano = false;

    [Header("Audio")]
    public AudioSource musica;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }

    public void IniciarMinijuego(AudioClip clip, GameObject canvas)
    {

        canvasMinijuego = canvas;

        if (canvasMinijuego != null)
            canvasMinijuego.SetActive(true);

        progreso = 0f;
        juegoTerminado = false;
        gano = false;

        if (barra != null)
            barra.value = 0;

        if (musica != null)
        {
            musica.Stop();
            musica.clip = clip;
            musica.Play();
        }
    }

    void Update()
    {
        if (barra != null)
            barra.value = progreso;

        if (!juegoTerminado && progreso >= maxProgreso)
        {
            Terminar(true);
        }
    }

    public void Correcto()
    {
        progreso += 10f;
        progreso = Mathf.Clamp(progreso, 0, maxProgreso);
    }

    public void Incorrecto()
    {
        progreso -= 15f;
        progreso = Mathf.Clamp(progreso, 0, maxProgreso);
    }

    public void Terminar(bool win)
    {
        juegoTerminado = true;
        gano = win;

        if (musica != null)
            musica.Stop();

        if (canvasMinijuego != null)
            canvasMinijuego.SetActive(false);

    }
}