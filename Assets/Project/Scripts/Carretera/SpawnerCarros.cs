using UnityEngine;
using System.Collections;

public class SpawnerCarros : MonoBehaviour
{
    public GameObject[] carros;

    public Transform puntoSpawn1;
    public Transform puntoSpawn2;

    public Transform destino1;
    public Transform destino2;

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
            int lado = Random.Range(0, 2);

            if (lado == 0)
            {
                SpawnCarro(puntoSpawn1, destino1);
            }
            else
            {
                SpawnCarro(puntoSpawn2, destino2);
            }

            yield return new WaitForSeconds(Random.Range(tiempoMin, tiempoMax));
        }
    }

    void SpawnCarro(Transform spawn, Transform destino)
    {
        GameObject carroElegido = carros[Random.Range(0, carros.Length)];

        GameObject nuevoCarro = Instantiate(carroElegido, spawn.position, Quaternion.identity);

        Carro scriptCarro = nuevoCarro.GetComponent<Carro>();
        scriptCarro.destino = destino;
        scriptCarro.velocidad = Random.Range(3f, 10f);
    }
}