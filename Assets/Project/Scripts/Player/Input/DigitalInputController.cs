using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DigitalInputController : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector2> onMove;
    [SerializeField] private UnityEvent onInteract;

    private bool isMoving;
    private Vector2 startPointPos;
    private Vector2 direction;


    private void Update() => CalculateMovementDirection();

    public void Interact() => onInteract?.Invoke();

    private void CalculateMovementDirection()
    {
        if(Touchscreen.current == null) return;

        if(!isMoving && Touchscreen.current.primaryTouch.press.isPressed)
        {
            if(EventSystem.current.IsPointerOverGameObject()) return;
            //start touch
            isMoving = true;
            startPointPos = Touchscreen.current.primaryTouch.position.ReadValue();
            return;
        }
        else if(isMoving && Touchscreen.current.primaryTouch.press.isPressed)
        {
            //update touch
            Vector2 currentPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            direction = (currentPosition - startPointPos).normalized;
            onMove?.Invoke(direction);
            return;
        }
        else if(isMoving && !Touchscreen.current.primaryTouch.press.isPressed)
        {
            //end Touch
            isMoving = false;
            direction = Vector2.zero;
            onMove?.Invoke(Vector2.zero);
            return;
        }
        onMove?.Invoke(Vector2.zero);
    }
}