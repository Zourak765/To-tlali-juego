using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoadScene : MonoBehaviour
{
    [SerializeField] private float tiempo = 6f;
    [SerializeField] private int escenaID = 6;

    void Start()
    {
        Invoke(nameof(CargarEscena), tiempo);
    }

    void CargarEscena()
    {
        SceneManager.LoadScene(escenaID);
    }
}