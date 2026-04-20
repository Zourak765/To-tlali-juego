using UnityEngine;
using System.Collections;

public class SpawnBusIzq : MonoBehaviour
{
    public GameObject[] buses;

    public Transform puntoSpawn;

    public float tiempoEntreBuses = 10f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnBusCarro();
            yield return new WaitForSeconds(tiempoEntreBuses);
        }
    }

    void SpawnBusCarro()
    {
        GameObject busElegido = buses[Random.Range(0, buses.Length)];

        Instantiate(busElegido, puntoSpawn.position, Quaternion.identity);
    }
}