using UnityEngine;

public class UIInventario : MonoBehaviour
{
    public GameObject panelInventario;
    public MonoBehaviour movimientoJugador;

    private bool abierto = false;

    void Start()
    {
        panelInventario.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            abierto = !abierto;

            panelInventario.SetActive(abierto);
            movimientoJugador.enabled = !abierto;
        }
    }
}