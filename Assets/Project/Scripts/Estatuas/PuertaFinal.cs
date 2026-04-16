using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaFinal : MonoBehaviour
{
    public GameManagerEstatuas controlador;
    public Collider2D colisionador; 

    private bool activado = false;

    void Start()
    {
        colisionador.enabled = false;
    }

    void Update()
    {
        if (!activado && TodasLasEstatuasActivas())
        {
            ActivarPuerta();
        }
    }

    bool TodasLasEstatuasActivas()
    {
        return controlador.GetEstatua(GameManagerEstatuas.listaestatua.Estatua1) &&
               controlador.GetEstatua(GameManagerEstatuas.listaestatua.Estatua2) &&
               controlador.GetEstatua(GameManagerEstatuas.listaestatua.Estatua3) &&
               controlador.GetEstatua(GameManagerEstatuas.listaestatua.Estatua4);
    }

    void ActivarPuerta()
    {
        activado = true;
        colisionador.enabled = true;

        Debug.Log("Todas las estatuas activadas 🔥");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activado) return;

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }
}