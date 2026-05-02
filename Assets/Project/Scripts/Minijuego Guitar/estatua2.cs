using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class estatua2 : MonoBehaviour
{
    [Header("Requisitos")]
    public string objetoRequerido = "Instrumento1";
    public GameManagerEstatuas controlador;
    public GameManagerEstatuas.listaestatua tipoEstatua;

    [Header("Jugador")]
    public GameObject jugador;
    public MonoBehaviour movimientoJugador;
    private bool jugadorCerca = false;

    [Header("Posición / Audio")]
    public Transform puntoDestino;
    public AudioClip musicaEstatua;
    public AudioSource musicaMundo;

    [Header("Minijuego")]
    public MiniJuegoManager miniJuegoManager;

    [Header("UI")]
    public GameObject mensajeError;
    public GameObject textoPerdiste;
    public SpriteRenderer estatuaRenderer;
    public Sprite estatuaActivada;

    private bool juegoIniciado = false;
    private bool yaActivada = false;

    void Start()
    {
        Debug.Log("🧩 Estatua inicializada: " + gameObject.name);

        if (textoPerdiste != null)
            textoPerdiste.SetActive(false);

        if (miniJuegoManager == null)
            Debug.LogError("❌ MiniJuegoManager NO asignado en estatua");

        if (controlador == null)
            Debug.LogError("❌ GameManagerEstatuas NO asignado");
    }

    void Update()
    {
        // 🔥 Estado visual
        if (!yaActivada && controlador != null && controlador.GetEstatua(tipoEstatua))
        {
            Debug.Log("✔ Estatua activada visualmente");
            ActivarEstatuaVisual();
        }

        // 🔥 INPUT E
        if (jugadorCerca)
        {
            if (Keyboard.current == null)
            {
                Debug.LogWarning("⚠ Keyboard.current es NULL");
                return;
            }

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("🎮 E presionada en estatua");
                ActivateStatue();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("📍 Trigger Enter: " + other.name);

        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            Debug.Log("✔ Jugador cerca activado");
        }
        else
        {
            Debug.Log("⚠ Trigger pero no Player: " + other.name);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            Debug.Log("📤 Jugador se alejó");
        }
    }

    public void ActivateStatue()
    {
        if (juegoIniciado)
        {
            Debug.Log("⛔ Juego ya iniciado");
            return;
        }

        Debug.Log("🚀 Activando estatua");

        if (InventMenu.instancia != null && InventMenu.instancia.TieneObjetoUnico(objetoRequerido))
        {
            StartCoroutine(SecuenciaCompleta());
        }
        else
        {
            Debug.Log("❌ No tiene objeto requerido");
            StartCoroutine(MostrarMensaje());
        }
    }

    IEnumerator SecuenciaCompleta()
    {
        Debug.Log("🎮 Iniciando secuencia");

        juegoIniciado = true;

        if (movimientoJugador != null)
            movimientoJugador.enabled = false;

        if (musicaMundo != null)
            musicaMundo.Pause();

        if (jugador != null && puntoDestino != null)
        {
            jugador.transform.position = puntoDestino.position;
            Debug.Log("📍 Jugador movido a estatua");
        }

        yield return new WaitForSeconds(0.5f);

        // 🔥 INICIAR MINIJUEGO
        if (miniJuegoManager != null)
        {
            Debug.Log("🚀 Iniciando minijuego");

            miniJuegoManager.IniciarMinijuego(
                musicaEstatua,
                miniJuegoManager.canvasMinijuego
            );
        }
        else
        {
            Debug.LogError("❌ MiniJuegoManager NULL");
            yield break;
        }

        // 🔥 ESPERAR FIN
        while (!miniJuegoManager.juegoTerminado)
        {
            yield return null;
        }

        Debug.Log("🏁 Minijuego terminado");

        bool resultado = miniJuegoManager.gano;

        if (controlador != null)
            controlador.SetEstatua(tipoEstatua, resultado);

        if (!resultado && textoPerdiste != null)
        {
            textoPerdiste.SetActive(true);
            yield return new WaitForSeconds(2f);
            textoPerdiste.SetActive(false);
        }

        if (miniJuegoManager.canvasMinijuego != null)
        {
            miniJuegoManager.canvasMinijuego.SetActive(false);
            Debug.Log("🧹 Canvas apagado");
        }

        if (musicaMundo != null)
            musicaMundo.UnPause();

        if (jugador != null)
        {
            Rigidbody2D rb = jugador.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = Vector2.zero;

            PlayerMovement mov = jugador.GetComponent<PlayerMovement>();
            if (mov != null)
                mov.SetDirection(Vector2.zero);
        }

        if (movimientoJugador != null)
            movimientoJugador.enabled = true;

        juegoIniciado = false;

        Debug.Log("✔ Secuencia finalizada");
    }

    void ActivarEstatuaVisual()
    {
        yaActivada = true;

        if (estatuaRenderer != null)
            estatuaRenderer.sprite = estatuaActivada;
    }

    IEnumerator MostrarMensaje()
    {
        Debug.Log("❌ Mostrando mensaje de error");

        if (mensajeError != null)
        {
            mensajeError.SetActive(true);
            yield return new WaitForSeconds(2f);
            mensajeError.SetActive(false);
        }
    }
}