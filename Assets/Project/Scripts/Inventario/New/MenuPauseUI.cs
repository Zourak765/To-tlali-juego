using UnityEngine;

public class MenuPauseUI : MonoBehaviour
{
    [SerializeField] private GameObject menuParent;

    [Space(4)]
    [SerializeField] private GameObject continuarButton;
    [SerializeField] private GameObject opcionesButton;
    [SerializeField] private GameObject menuPrincipalButton;

    private bool isOpened;
    private Player currentPlayer;

    private void Awake() => currentPlayer = FindFirstObjectByType<Player>();

    public void Open()
    {
        menuParent.SetActive(true);
        currentPlayer.Deactivate("Menu");

        continuarButton.SetActive(true);
        opcionesButton.SetActive(true);
        menuPrincipalButton.SetActive(true);
    }

    public void Close()
    {
        menuParent.SetActive(false);
        currentPlayer.Activate("Menu");
    }

    public void ToggleUI()
    {
        isOpened = !isOpened;

        if (isOpened) Open();
        else Close();
    }
}