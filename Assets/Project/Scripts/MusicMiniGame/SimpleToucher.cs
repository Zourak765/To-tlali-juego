using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SimpleToucher : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UnityEvent onTouch;

    public void OnPointerClick(PointerEventData eventData)
    {
        onTouch?.Invoke();
    }
}
