using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private PlayerInput input;

    public InputAction Interaction{get; private set;}
    public InputAction Run{get; private set;}

    public Vector2 MovementDir {get; private set;}


    private void Awake()
    {
        Interaction = input.actions["Interaction"];
        Run = input.actions["Run"];
    }

    public void CalculateMovement(InputAction.CallbackContext ctx) => MovementDir = ctx.ReadValue<Vector2>();
    public void SetMovement(Vector2 _dir) => MovementDir = _dir;
}