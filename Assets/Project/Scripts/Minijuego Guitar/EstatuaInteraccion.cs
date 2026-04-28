using UnityEngine;
using System.Collections;

public class EstatuaInteraccion : MonoBehaviour
{
    public string objetoRequerido = "Instrumento1";
    public GameManagerEstatuas controlador;

    public GameManagerEstatuas.listaestatua tipoEstatua;

    public GameObject mensajeError;
    public Transform puntoDestino;
    public GameObject jugador;
    public MonoBehaviour movimientoJugador;
    public AudioClip musicaEstatua;
    public AudioSource musicaMundo;

    public MiniJuegoManager miniJuegoManager;
    public Sprite estatuaActivada;
    public GameObject textoPerdiste;

    public SpriteRenderer estatuaRenderer;

    private bool juegoIniciado = false;
    private bool yaActivada = false;

    void Start()
    {
        textoPerdiste.SetActive(false);
    }

    void Update()
    {
        if (!yaActivada && controlador.GetEstatua(tipoEstatua))
        {
            ActivarEstatuaVisual();
        }
    }

    public void ActivateStatue()
    {
        if (juegoIniciado) return;

        if (InventMenu.instancia.TieneObjetoUnico(objetoRequerido)) StartCoroutine(SecuenciaCompleta());
        else StartCoroutine(MostrarMensaje());
    }

    IEnumerator SecuenciaCompleta()
    {
        juegoIniciado = true;
        movimientoJugador.enabled = false;

        if (musicaMundo != null)
            musicaMundo.Pause();

        jugador.transform.position = puntoDestino.position;
        yield return new WaitForSeconds(0.5f);

        miniJuegoManager.IniciarMinijuego(musicaEstatua, miniJuegoManager.canvasMinijuego);

        while (!miniJuegoManager.juegoTerminado)
            yield return null;

        bool resultado = miniJuegoManager.gano;

        controlador.SetEstatua(tipoEstatua, resultado);

        if (!resultado)
        {
            textoPerdiste.SetActive(true);
            yield return new WaitForSeconds(2f);
            textoPerdiste.SetActive(false);
        }

        miniJuegoManager.canvasMinijuego.SetActive(false);

        if (musicaMundo != null)
            musicaMundo.UnPause();

        Rigidbody2D rb = jugador.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = Vector2.zero;

        PlayerMovement mov = jugador.GetComponent<PlayerMovement>();
        if (mov != null)
            mov.SetDirection(Vector2.zero);

        movimientoJugador.enabled = true;
        juegoIniciado = false;
    }

    void ActivarEstatuaVisual()
    {
        yaActivada = true;

        if (estatuaRenderer != null)
            estatuaRenderer.sprite = estatuaActivada;
    }

    IEnumerator MostrarMensaje()
    {
        mensajeError.SetActive(true);
        yield return new WaitForSeconds(2f);
        mensajeError.SetActive(false);
    }
}