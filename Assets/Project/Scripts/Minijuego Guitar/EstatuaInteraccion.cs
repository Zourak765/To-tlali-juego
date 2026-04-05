using UnityEngine;
using System.Collections;

public class EstatuaInteraccion : MonoBehaviour
{
    public string objetoRequerido = "Instrumento";
    public GameObject mensajeError;

    public Transform puntoDestino;

    public GameObject jugador;

    public MonoBehaviour movimientoJugador;

    public SpriteRenderer estatuaRenderer;
    public Sprite estatuaActivada;

    public GameObject textoPerdiste;

    private bool enZona = false;

    void Start()
    {
        textoPerdiste.SetActive(false);
    }

    void Update()
    {
        if (enZona && Input.GetKeyDown(KeyCode.E))
        {
            if (InventMenu.instancia.TieneObjeto(objetoRequerido))
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
        movimientoJugador.enabled = false;

        jugador.transform.position = puntoDestino.position;

        yield return new WaitForSeconds(2f);

        MiniJuegoManager.instancia.IniciarMinijuego();

        yield return new WaitUntil(() =>
            MiniJuegoManager.instancia != null &&
            MiniJuegoManager.instancia.juegoTerminado
        );

        if (MiniJuegoManager.instancia.gano)
        {
            estatuaRenderer.sprite = estatuaActivada;
            yield return new WaitForSeconds(2f);
        }
        else
        {
            textoPerdiste.SetActive(true);
            yield return new WaitForSeconds(2f);
            textoPerdiste.SetActive(false);
        }

        MiniJuegoManager.instancia.canvasMinijuego.SetActive(false);

        movimientoJugador.enabled = true;
    }

    IEnumerator MostrarMensaje()
    {
        mensajeError.SetActive(true);
        yield return new WaitForSeconds(2f);
        mensajeError.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enZona = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enZona = false;
        }
    }
}