using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeGame : MonoBehaviour
{
    public string sceneName;
    public float minimTime = 1f;

    void Start()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneName);
        load.allowSceneActivation = false;

        float time = 0f;

        while (load.progress < 0.9f)
        {
            time += Time.deltaTime;
            yield return null;
        }

        while (time < minimTime)
        {
            time += Time.deltaTime;
            yield return null;
        }

        load.allowSceneActivation = true;
    }
}