using UnityEngine;
using UnityEngine.Events;

public class SimpleInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent onInteract;
    public void Interact() => onInteract?.Invoke();
}