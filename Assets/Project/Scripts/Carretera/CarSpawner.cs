using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] prefabsCarros;
    public Transform puntoSpawn;
    public float tiempoEntreSpawn = 2f;
    public int direccion = 1;
    public float velocidad = 5f;

    public Transform puntoTeleport;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnCarro();
            yield return new WaitForSeconds(tiempoEntreSpawn);
        }
    }

    void SpawnCarro()
    {
        GameObject carro = Instantiate(prefabsCarros[Random.Range(0, prefabsCarros.Length)], puntoSpawn.position, Quaternion.identity);

        Rigidbody2D rb = carro.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = new Vector2(direccion * velocidad, 0f);
        }

        if (direccion == -1)
        {
            Vector3 escala = carro.transform.localScale;
            escala.x *= -1;
            carro.transform.localScale = escala;
        }

        TPCAR tp = carro.GetComponent<TPCAR>();
        if (tp != null)
        {
            tp.targetPosTransform = puntoTeleport;
        }
    }
}
