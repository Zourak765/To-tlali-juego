using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField, Min(0f)] private float radius;
    [SerializeField] private Vector2 offset;
    [SerializeField] private LayerMask mask;

    private IInteractable detectedInteractable;

    public void TryInteract()
    {
        if(detectedInteractable != null) detectedInteractable.Interact();
    }

    public void DetectInteractables()
    {
        Vector2 center = (Vector2)transform.position + offset;
        Collider2D[] detectedCols = Physics2D.OverlapCircleAll(center, radius, mask);

        IInteractable currentInteractable = null;
        foreach (Collider2D col in detectedCols)
        {
            if(!col.TryGetComponent(out IInteractable interactable)) continue;
            currentInteractable = interactable;
        }
        detectedInteractable = currentInteractable;
    }

    private void OnDrawGizmos()
    {
        Vector2 center = (Vector2)transform.position + offset;
        Gizmos.DrawWireSphere(center, radius);        
    }

}