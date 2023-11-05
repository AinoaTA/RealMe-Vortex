using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LoaderScenes : MonoBehaviour
{
    public static LoaderScenes Instance { get; private set; }

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    /// Add a new scene additive to current one. Perfect for load that necessary levels
    /// </summary>
    /// <param name="scene"></param>
    public void LoadAdditiveScene(string scene)
    {
        StartCoroutine(LoadSceneLoading(scene));
    }

    IEnumerator LoadSceneLoading(string scene)
    {
        SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive);

        AsyncOperation level = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);

        yield return new WaitUntil(() => level.isDone);

        //SceneManager.UnloadSceneAsync("Loading");
    }

    /// <summary>
    /// Unload an additive scene.
    /// </summary>
    /// <param name="scene"></param>
    public void UnloadScene(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }
     
    public void LoadScene(string namescene)
    {
        SceneManager.LoadScene(namescene);
    }
}