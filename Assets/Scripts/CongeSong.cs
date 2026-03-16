using UnityEngine;

public class CongeSong : MonoBehaviour
{
    public static bool cancionTerminada = false;

    AudioSource musica;

    void Start()
    {
        musica = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!musica.isPlaying && !cancionTerminada)
        {
            cancionTerminada = true;
        }
    }
}