using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoT : MonoBehaviour
{
    float t = 0;
    bool cambioS = false;

    void Start()
    {
        StartCoroutine(Count());
    }

    void Update()
    {
        GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, t);

        if (cambioS)
        {
            SceneManager.LoadScene(1);
        }
    }

    public IEnumerator Count()
    {
        print(t);
        yield return new WaitForSeconds(1f);
        if (t == 0)
        {
            StartCoroutine(Fade());
        }
        else
        {
            StartCoroutine(Fades());
        }
    }

    public IEnumerator Fade()
    {
        yield return new WaitForSeconds(0.05f);
        if (t < 1)
        {
            t = t + 0.1f;
        }

        if (t >= 1)
        {
            StartCoroutine(Count());
        }

        StartCoroutine(Fade());
    }

    public IEnumerator Fades()
    {
        yield return new WaitForSeconds(0.05f);
        if (t > 0)
        {
            t = t - 0.1f;
        }

        if (t <= 0)
        {
            cambioS = true;
        }
        StartCoroutine(Fades());
    }

}