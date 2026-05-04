using UnityEngine;

public class ObjetoColect : MonoBehaviour
{
    [SerializeField] private Inventory.InventoryItem itemType;
    public AudioClip sonido;

    private Inventory currentInventory;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (sonido != null) AudioSource.PlayClipAtPoint(sonido, transform.position);

            if(currentInventory == null) currentInventory = FindFirstObjectByType<Inventory>();
            currentInventory.UnlockInstrument(itemType);
            Destroy(gameObject);
        }
    }
}