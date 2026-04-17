using System.Collections.Generic;
using UnityEngine;

public class InventMenu : MonoBehaviour
{
    public static InventMenu instancia;

    public List<string> objetosUnicos = new List<string>();
    public Dictionary<string, int> objetosCantidad = new Dictionary<string, int>();

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

    public void AgregarObjeto(string tagObjeto, bool esAcumulable)
    {
        if (esAcumulable)
        {
            if (objetosCantidad.ContainsKey(tagObjeto))
                objetosCantidad[tagObjeto]++;
            else
                objetosCantidad[tagObjeto] = 1;
        }
        else
        {
            if (!objetosUnicos.Contains(tagObjeto))
                objetosUnicos.Add(tagObjeto);
        }

        alCambiarInventario?.Invoke();
    }

    public bool TieneObjetoUnico(string tagObjeto)
    {
        return objetosUnicos.Contains(tagObjeto);
    }

    public int CantidadObjeto(string tagObjeto)
    {
        return objetosCantidad.ContainsKey(tagObjeto) ? objetosCantidad[tagObjeto] : 0;
    }
}