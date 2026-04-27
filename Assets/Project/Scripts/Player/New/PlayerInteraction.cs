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
            //si no encuentra el componente (interfaz) IInteractable, pasa al sig elemento.
            if(!col.TryGetComponent(out IInteractable interactable)) continue;
            // si si lo encontro:
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