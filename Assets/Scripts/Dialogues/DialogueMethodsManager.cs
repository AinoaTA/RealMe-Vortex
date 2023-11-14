using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "SO/Manager Methods")]
public class DialogueMethodsManager : ScriptableObject
{
    public static Action CallBackOnEnd;
    public ItemCategory items;

    public void CallbackOnEnd()
    {
        CallBackOnEnd?.Invoke();

        CallBackOnEnd = null;
    }

    public void UpdateToGameplayState()
    {
        GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.GAMEPLAY);
    }

    public void UpdateToMinigameState()
    {
        GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.MINIGAME);
    }

    public void LoadAdditiveScn(string sceneName)
    {
        LoaderScenes.Instance.LoadAdditiveScene(sceneName);
    }

    public void LoadScn(string sceneName)
    {
        LoaderScenes.Instance.LoadScene(sceneName);
    }

    public void FadeIn()
    {
        FadesController.Instance.FadeIn();
    }

    public void FadeOut()
    {
        FadesController.Instance.FadeOut();
    }

    public void BlinkFadeOut()
    {
        FadesController.Instance.BlinkFadeOut();
    }

    public void AddItem(int itemtype)
    {
        Debug.Log(items.GetItem(itemtype).ObjectName);
        Inventory.instance.AddItem(items.GetItem(itemtype), 1);
    }

    public void AddItem(Item itemtype)
    {
        //Debug.Log(items.GetItem(itemtype).ObjectName);
        Inventory.instance.AddItem(itemtype, 1);
    }


    public void MustFollowPlayer(bool follow)
    {
        GameManager.instance.MustFollowPlayer = follow;
    }

    #region CameraEffects
    public void IsWorseEffect(bool worse)
    {
        GameController.Instance.CamData.ObscureVignetteRad(worse);
    }

    #endregion

    public void SpecificSoundFMOD(string eventPath)
    {
        FMODUnity.RuntimeManager.PlayOneShot(eventPath);
    }

    public void TrustedInElek(bool trusted) 
    {
        GameManager.instance.TrustedInElek = trusted;
    }
}