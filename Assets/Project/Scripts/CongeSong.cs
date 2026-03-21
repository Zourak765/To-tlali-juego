using UnityEngine;

public class CongeSong : MonoBehaviour
{
    public static bool cancionTerminada = false;

    public GameObject panelFinal; 

    AudioSource musica;

    void Start()
    {
        musica = GetComponent<AudioSource>();

        if (panelFinal != null)
        {
            panelFinal.SetActive(false); 
        }
    }

    void Update()
    {
        if (musica != null)
        {
            if (!musica.isPlaying && !cancionTerminada)
            {
                cancionTerminada = true;

                if (panelFinal != null)
                {
                    panelFinal.SetActive(true); 
                }
            }
        }
    }
}