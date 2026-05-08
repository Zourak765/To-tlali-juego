using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public enum InventoryItem {Instrumento1, Instrumento2, Instrumento3, Instrumento4}

    [SerializeField] private UnityEvent<bool,bool,bool,bool> onInventoryUpdated;

    private bool instrumento1, instrumento2, instrumento3, instrumento4;

    public void UnlockInstrument(InventoryItem _item)
    {
        switch(_item)
        {
            case InventoryItem.Instrumento1:
            instrumento1 = true;
            break;
            case InventoryItem.Instrumento2:
            instrumento2 = true;
            break;
            case InventoryItem.Instrumento3:
            instrumento3 = true;
            break;
            case InventoryItem.Instrumento4:
            instrumento4 = true;
            break;
        }
        onInventoryUpdated?.Invoke(instrumento1, instrumento2, instrumento3, instrumento4);
    }


    public bool GetItemState(InventoryItem _item)
    {
        switch(_item)
        {
            case InventoryItem.Instrumento1:
            return instrumento1;
            case InventoryItem.Instrumento2:
            return instrumento2;
            case InventoryItem.Instrumento3:
            return instrumento3;
            case InventoryItem.Instrumento4:
            return instrumento4;
        }
        return false;
    }
}