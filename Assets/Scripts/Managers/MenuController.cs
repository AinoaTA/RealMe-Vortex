using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void Play()
    {
        LoaderScenes.Instance.LoadAdditiveScene("FirstScene_OniricFall");
    }

    public void OpenOptions()
    {

    }
}