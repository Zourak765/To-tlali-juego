using UnityEngine;

public class PlayerInicio : MonoBehaviour
{
    public Transform puntoInicio;

    public void RegresarAlInicio()
    {
        transform.position = puntoInicio.position;
    }
}