using UnityEngine;

public class CreditosUI : MonoBehaviour
{
    [SerializeField] private GameObject panelOpciones;
    [SerializeField] private GameObject panelCreditos;

    public void OpenCredits()
    {
        panelOpciones.SetActive(false);
        panelCreditos.SetActive(true);
    }

    public void BackToOptions()
    {
        panelCreditos.SetActive(false);
        panelOpciones.SetActive(true);
    }
}