using UnityEngine;
using UnityEngine.UI;

public class CambioUI : MonoBehaviour
{
    public RawImage instrumento1;
    public RawImage instrumento2;
    public RawImage instrumento3;
    public RawImage instrumento4;

    public Text textoSemillas;

    void Start()
    {
        InventMenu.instancia.alCambiarInventario += ActualizarUI;
    }

    void ActualizarUI()
    {
        if (InventMenu.instancia.TieneObjetoUnico("Instrumento1"))
            instrumento1.color = Color.white;

        if (InventMenu.instancia.TieneObjetoUnico("Instrumento2"))
            instrumento2.color = Color.white;

        if (InventMenu.instancia.TieneObjetoUnico("Instrumento3"))
            instrumento3.color = Color.white;

        if (InventMenu.instancia.TieneObjetoUnico("Instrumento4"))
            instrumento4.color = Color.white;


        int semillas = InventMenu.instancia.CantidadObjeto("Semilla");
        textoSemillas.text = "x" + semillas;
    }
}