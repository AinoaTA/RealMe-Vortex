using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "SO/Manager Methods")]
public class DialogueMethodsManager : ScriptableObject
{
    public static Action CallBackOnEnd;

    public void CallbackOnEnd()
    {
        CallBackOnEnd?.Invoke();

        CallBackOnEnd = null;
    }

    public void UpdateToGameplayState()
    {
        Main.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.GAMEPLAY);
    }

    public void UpdateToMinigameState()
    {
        Main.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.MINIGAME);
    }

    public void LoadAdditiveScn(string sceneName)
    {
        LoaderScenes.Instance.LoadAdditiveScene(sceneName);
    }

    public void LoadScn(string sceneName)
    {
        LoaderScenes.Instance.LoadScene(sceneName);
    }
}