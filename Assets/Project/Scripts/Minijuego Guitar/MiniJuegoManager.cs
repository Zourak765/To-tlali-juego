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

        Debug.Log("🎮 MiniJuegoManager listo");
    }

    // 🔥 ESTE ES EL MÉTODO QUE DEBES USAR EN TODO EL PROYECTO
    public void IniciarMinijuego(AudioClip clip, GameObject canvas)
    {
        Debug.Log("🚀 IniciarMinijuego llamado");

        canvasMinijuego = canvas;

        if (canvasMinijuego != null)
            canvasMinijuego.SetActive(true);
        else
            Debug.LogError("❌ Canvas no asignado");

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
        else
        {
            Debug.LogError("❌ AudioSource no asignado");
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
        Debug.Log("✔ Correcto → " + progreso);
    }

    public void Incorrecto()
    {
        progreso -= 15f;
        progreso = Mathf.Clamp(progreso, 0, maxProgreso);
        Debug.Log("❌ Incorrecto → " + progreso);
    }

    public void Terminar(bool win)
    {
        juegoTerminado = true;
        gano = win;

        if (musica != null)
            musica.Stop();

        if (canvasMinijuego != null)
            canvasMinijuego.SetActive(false);

        Debug.Log("🏁 Fin del minijuego");
    }
}