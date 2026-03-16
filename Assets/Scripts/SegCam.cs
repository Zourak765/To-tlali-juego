using UnityEngine;

public class SegCam : MonoBehaviour
{
    public Transform jugador;
    public Vector3 distancia;

    void LateUpdate()
    {
        transform.position = jugador.position + distancia;
    }
}