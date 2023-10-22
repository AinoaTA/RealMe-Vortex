using UnityEngine;


public enum TypeMenu { PAUSE, OPTIONS, OTHER }
public class UIManager : MonoBehaviour, IInitialize
{
    private CanvasGroup _canvasGroup;
    private bool _paused;


    private void OnEnable()
    {
        InputManager.Pause += OnPause;
    }

    private void OnDisable()
    {
        InputManager.Pause -= OnPause;
    }

    public void InitializeAwake()
    {
        TryGetComponent(out _canvasGroup);
    }

    public void OnPause()
    {
        _paused = !_paused;

        Time.timeScale = _paused ? 0 : 1;

        StatusMenu(_canvasGroup, _paused);
    }

    public void StatusMenu(CanvasGroup cg, bool show)
    {
        cg.alpha = show ? 1 : 0;
        cg.blocksRaycasts = show;
        cg.interactable = show;
    }

    public void BackMenu()
    {
        LoaderScenes.Instance.LoadAdditiveScene("Menu");
    }
}
