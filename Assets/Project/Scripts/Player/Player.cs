using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerInteraction interaction;
    [SerializeField] private PlayerAnimations animations;

    private bool isActive = true;
    private List<string> deactivationCalls = new List<string>();

    private Vector2 inputDirection;

    private void Awake()
    {
        movement?.Initialize();
    }
    private void Update()
    {
        interaction?.DetectInteractables();

        TryMove();
    }
    private void FixedUpdate()
    {
        movement?.TickPhysics();   
    }

    public void Deactivate(string _callID)
    {
        if(!deactivationCalls.Contains(_callID)) deactivationCalls.Add(_callID);
        isActive = false;

        movement.Stop();
        animations.SetVelocity(Vector2.zero);
    }
    public void Activate(string _callID)
    {
        if(deactivationCalls.Contains(_callID)) deactivationCalls.Remove(_callID);
        if(deactivationCalls.Count == 0) isActive = true;
    }

    public void Teleport(Vector2 _newPos)
    {
        Deactivate("");
        if(movement != null) movement.Teleport(_newPos);
        else transform.position = _newPos;
        Activate("");
    }

    public void InputDirection(InputAction.CallbackContext ctx) => inputDirection = ctx.ReadValue<Vector2>();
    
    public void InputInteraction(InputAction.CallbackContext ctx)
    {
       if(ctx.performed) TryInteract(); 
    }


    private void TryMove()
    {
        if(!isActive || movement == null) return;
        movement.SetDirection(inputDirection);
        animations.SetVelocity(movement.Velocity);
    }
    private void TryInteract()
    {
        if (!isActive || interaction == null) return;
        interaction.TryInteract();
    }
}
