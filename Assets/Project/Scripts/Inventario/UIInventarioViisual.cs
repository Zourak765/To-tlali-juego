using UnityEngine;

public class UIInventarioVisual : MonoBehaviour
{
    [Header("Objetos en escena")]
    public SpriteRenderer instrumentoRenderer;
    public SpriteRenderer semillasRenderer;

    void Start()
    {
        ActualizarInventario();

        InventMenu.instancia.alCambiarInventario += ActualizarInventario;
    }

    void ActualizarInventario()
    {
        if (InventMenu.instancia.TieneObjeto("Instrumento"))
        {
            instrumentoRenderer.color = Color.white;
        }
        else
        {
            instrumentoRenderer.color = Color.black;
        }

        if (InventMenu.instancia.TieneObjeto("Semillas"))
        {
            semillasRenderer.color = Color.white;
        }
        else
        {
            semillasRenderer.color = Color.black;
        }
    }
}