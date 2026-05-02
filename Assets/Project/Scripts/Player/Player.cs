using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputController input;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerInteraction interaction;
    [SerializeField] private PlayerAnimations animations;

    private bool isActive = true;
    private List<string> deactivationCalls = new List<string>();

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

    private void TryMove()
    {
        if(!isActive || movement == null) return;

        Vector2 inputDirection = input.MovementDir;
        movement.SetDirection(inputDirection);
        animations.SetVelocity(movement.Velocity);
    }
    private void TryInteract()
    {
        if (!isActive || interaction == null) return;

        if (input.Interaction.WasPressedThisFrame())
        {
            interaction.TryInteract();
        }
    }
}
