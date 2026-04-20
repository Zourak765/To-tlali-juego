using UnityEngine;
using System.Collections;

public class SpawnerCarros : MonoBehaviour
{
    public GameObject[] carros;

    public Transform puntoSpawn;
    public Transform destino;

    public float tiempoMin = 1f;
    public float tiempoMax = 3f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnCarro();
            yield return new WaitForSeconds(Random.Range(tiempoMin, tiempoMax));
        }
    }

    void SpawnCarro()
    {
        GameObject carroElegido = carros[Random.Range(0, carros.Length)];

        GameObject nuevoCarro = Instantiate(carroElegido, puntoSpawn.position, Quaternion.identity);

        Carro carroScript = nuevoCarro.GetComponent<Carro>();
        carroScript.destino = destino;
    }
}