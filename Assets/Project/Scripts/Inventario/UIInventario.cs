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
        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     ToggleInventario();
        // }
    }

    public void ToggleInventario()
    {
        abierto = !abierto;

        panelInventario.SetActive(abierto);

        if (movimientoJugador != null)
        {
            movimientoJugador.enabled = !abierto;
        }
    }
}