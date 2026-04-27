using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float defaultSpeed;

    private Rigidbody2D body;

    private Vector2 targetDirection;
    private Vector2 velocity;

    public Vector2 Velocity => velocity;

    public void Initialize() => SetupRigidbody();
    public void TickPhysics() => Move();

    public void SetDirection(Vector2 _dir) => targetDirection = _dir.normalized;

    private void Move()
    {
        velocity = targetDirection * defaultSpeed;
        body.linearVelocity = velocity;
    }

    private void SetupRigidbody()
    {
        if(body == null) body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        body.gravityScale = 0f;
        body.interpolation = RigidbodyInterpolation2D.Interpolate;
        body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;  
    }
}