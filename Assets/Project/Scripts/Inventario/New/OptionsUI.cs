using UnityEngine;

public class OptionsUI : MonoBehaviour
{
    [SerializeField] private GameObject menuPrincipal; 
    [SerializeField] private GameObject panelOpciones;

    private bool isOpened;
    private Player currentPlayer;

    private void Awake() => currentPlayer = FindFirstObjectByType<Player>();

    public void OpenMenu()
    {
        isOpened = true;
        menuPrincipal.SetActive(true);
        panelOpciones.SetActive(false);

        currentPlayer.Deactivate("Menu");
    }
    public void CloseMenu()
    {
        isOpened = false;
        menuPrincipal.SetActive(false);
        panelOpciones.SetActive(false);

        currentPlayer.Activate("Menu");
    }
    public void ToggleMenu()
    {
        if (isOpened) CloseMenu();
        else OpenMenu();
    }
    public void OpenOptions()
    {
        menuPrincipal.SetActive(false);
        panelOpciones.SetActive(true);
    }
    public void BackToMenu()
    {
        panelOpciones.SetActive(false);
        menuPrincipal.SetActive(true);
    }
}