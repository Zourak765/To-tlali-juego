using UnityEngine;
using System.Collections;

public class SpawnBus : MonoBehaviour
{
    public GameObject[] carros; 

    public Transform puntoSpawn;
    public Transform destino;

    public float tiempoEntreBuses = 10f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnCarro();

            yield return new WaitForSeconds(tiempoEntreBuses);
        }
    }

    void SpawnCarro()
    {
        GameObject busElegido = carros[Random.Range(0, carros.Length)];

        GameObject nuevoBus = Instantiate(busElegido, puntoSpawn.position, Quaternion.identity);

        Carro carroScript = nuevoBus.GetComponent<Carro>();
        carroScript.destino = destino;
    }
}