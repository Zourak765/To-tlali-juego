using UnityEngine;

public class GlobalAudio : MonoBehaviour
{
    public void SetVolume(float v)
    {
        v = Mathf.Clamp(v, 0.0001f, 1f); 
        AudioListener.volume = v;
    }
}