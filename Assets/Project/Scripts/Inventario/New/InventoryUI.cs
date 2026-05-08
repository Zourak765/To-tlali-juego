using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryParent;
    [Space(4)]
    [SerializeField] private Image instrumento1Image;
    [SerializeField] private Image instrumento2Image;
    [SerializeField] private Image instrumento3Image;
    [SerializeField] private Image instrumento4Image;

    private bool isOpened;
    private Player currentPlayer;

    private void Awake() => currentPlayer = FindFirstObjectByType<Player>();

    public void Open()
    {
        inventoryParent.SetActive(true);
        currentPlayer.Deactivate("Inventory");
    }

    public void Close()
    {
        inventoryParent.SetActive(false);
        currentPlayer.Activate("Inventory");
    }

    public void ToggleUI()
    {
        isOpened = !isOpened;
        if(isOpened) Open();
        else Close();
    }

    public void UpdateUI(bool _i1State, bool _i2State, bool _i3State, bool _i4State)
    {
        instrumento1Image.enabled = _i1State;   
        instrumento2Image.enabled = _i2State;   
        instrumento3Image.enabled = _i3State;   
        instrumento4Image.enabled = _i4State;   
    }
}