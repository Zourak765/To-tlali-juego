using UnityEngine;

public class Teletransporte: MonoBehaviour
{
    [SerializeField] private Transform targetPosTransform;
    [SerializeField] private Vector2 offset;

    private Player currentPlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if(currentPlayer == null) currentPlayer = other.GetComponent<Player>();
        if(currentPlayer == null) return;

        currentPlayer.Teleport(targetPosTransform.position + (Vector3)offset);
    }

    private void OnDrawGizmos()
    {
        if(targetPosTransform == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPosTransform.position + (Vector3)offset, .2f);   
    }
}