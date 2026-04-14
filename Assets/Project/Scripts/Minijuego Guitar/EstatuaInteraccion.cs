using UnityEngine;
using System.Collections;

public class EstatuaInteraccion : MonoBehaviour
{
    public string objetoRequerido = "Instrumento1";
    public GameManagerEstatuas controlador;
    public GameObject mensajeError;
    public Transform puntoDestino;
    public GameObject jugador;
    public MonoBehaviour movimientoJugador;
    public AudioClip musicaEstatua;
    public AudioSource musicaMundo;

    public MiniJuegoManager miniJuegoManager; 
    public Sprite estatuaActivada;
    public GameObject textoPerdiste;

    private bool enZona = false;
    private bool juegoIniciado = false;
    private SpriteRenderer estatuaRenderer;

    void Start()
    {
        estatuaRenderer = GetComponentInChildren<SpriteRenderer>();
        textoPerdiste.SetActive(false);
    }

    void Update()
    {
        if (enZona && Input.GetKeyDown(KeyCode.E) && !juegoIniciado)
        {
            if (InventMenu.instancia.TieneObjetoUnico(objetoRequerido))
            {
                StartCoroutine(SecuenciaCompleta());
            }
            else
            {
                StartCoroutine(MostrarMensaje());
            }
        }
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
        controlador.SetEstatua1(resultado);

        if (resultado)
        {
            if (estatuaRenderer != null)
                estatuaRenderer.sprite = estatuaActivada;
           
        }
        else
        {
            textoPerdiste.SetActive(true);
            yield return new WaitForSeconds(2f);
            textoPerdiste.SetActive(false);
        }

        miniJuegoManager.canvasMinijuego.SetActive(false);

        if (musicaMundo != null)
            musicaMundo.UnPause();

        movimientoJugador.enabled = true;
        juegoIniciado = false;
    }

    IEnumerator MostrarMensaje()
    {
        mensajeError.SetActive(true);
        yield return new WaitForSeconds(2f);
        mensajeError.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) enZona = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) enZona = false;
    }
}