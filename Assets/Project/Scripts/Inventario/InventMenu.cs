using System.Collections.Generic;
using UnityEngine;

public class InventMenu : MonoBehaviour
{
    public static InventMenu instancia;

    public List<string> objetos = new List<string>();

    public delegate void CambioInventario();
    public event CambioInventario alCambiarInventario;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarObjeto(string tagObjeto)
    {
        if (!objetos.Contains(tagObjeto))
        {
            objetos.Add(tagObjeto);

            if (alCambiarInventario != null)
            {
                alCambiarInventario.Invoke();
            }
        }
    }

    public bool TieneObjeto(string tagObjeto)
    {
        return objetos.Contains(tagObjeto);
    }
}