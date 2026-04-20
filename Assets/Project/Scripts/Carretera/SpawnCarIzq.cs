using UnityEngine;
using System.Collections;

public class SpawnCarIzq : MonoBehaviour
{
    public GameObject[] carros;

    public Transform puntoSpawn; 
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
        Instantiate(carroElegido, puntoSpawn.position, Quaternion.identity);
    }
}