using UnityEngine;

public class MenuController : MonoBehaviour
{ 
    private void Start()
    {
        FMODSpecial.instance.ChangeMusic(EnumsData.MusicScene.MENU);
    }

    public void Play()
    {
        LoaderScenes.Instance.LoadAdditiveScene("FirstScene_OniricFall");
    }

    public void OpenOptions()
    {

    }


    public void UISound() 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/UI/ClickUI");
    }
}