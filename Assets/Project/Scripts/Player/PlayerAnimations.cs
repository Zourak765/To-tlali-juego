using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private static readonly int IS_WALKING = Animator.StringToHash("IsWalking");

    [SerializeField] private Animator anim;
    [SerializeField] private Transform flipable;

    public void SetVelocity(Vector2 _velocity)
    {
        anim.SetBool(IS_WALKING, _velocity.magnitude != 0);
        Vector2 dir = _velocity.normalized;
        SetFacing(dir.x);
    }
    public void SetFacing(float _xDir)
    {
        if(_xDir > 0f) flipable.localScale = new Vector3(-1,1,1);
        else if(_xDir < 0f) flipable.localScale = new Vector3(1,1,1);
    }
}