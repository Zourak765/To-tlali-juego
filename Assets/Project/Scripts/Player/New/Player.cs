using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputController input;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerInteraction interaction;
    [SerializeField] private PlayerAnimations animations;


    private void Awake()
    {
        movement?.Initialize();
    }
    private void Update()
    {
        interaction?.DetectInteractables();

        TryMove();
        TryInteract();
    }
    private void FixedUpdate()
    {
        movement?.TickPhysics();   
    }

    private void TryMove()
    {
        if(movement == null) return;

        Vector2 inputDirection = input.MovementDir;
        movement.SetDirection(inputDirection);
        animations.SetVelocity(movement.Velocity);
    }

    private void TryInteract()
    {
        if (interaction == null) return;

        if (input.Interaction.WasPressedThisFrame()
            || Input.GetMouseButtonDown(0))
        {
            interaction.TryInteract();
        }
    }
}
