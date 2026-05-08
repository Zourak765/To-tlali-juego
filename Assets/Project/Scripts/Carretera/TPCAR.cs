using UnityEngine;

public class TPCAR : MonoBehaviour
{
    public Transform targetPosTransform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Player player = other.GetComponent<Player>();
        if (player == null) return;

        player.Teleport(targetPosTransform.position);
    }
}
