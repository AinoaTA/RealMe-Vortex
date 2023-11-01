using UnityEngine;

public class Load : MonoBehaviour
{
    public void LoadAdditiveScn(string sceneName) 
    {
        LoaderScenes.Instance.LoadAdditiveScene(sceneName);
    }

    public void LoadScn(string sceneName)
    {
        LoaderScenes.Instance.LoadScene(sceneName);
    }
} 