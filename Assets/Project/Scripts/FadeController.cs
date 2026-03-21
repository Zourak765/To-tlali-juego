using UnityEngine;

public class FadeController : MonoBehaviour
{
    public GameObject cuadroNegro;

    public void FadeNegro()
    {
        cuadroNegro.SetActive(true); 
    }

    public void QuitarNegro()
    {
        cuadroNegro.SetActive(false); 
    }
}
