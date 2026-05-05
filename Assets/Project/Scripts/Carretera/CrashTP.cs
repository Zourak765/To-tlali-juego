using UnityEngine;

public class CrashTP : MonoBehaviour
{
    public Transform zona1;
    public Transform zona2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (CompareTag("Zona1"))
        {
            other.transform.position = zona1.position;
        }
        else if (CompareTag("Zona2"))
        {
            other.transform.position = zona2.position;
        }
    }
}