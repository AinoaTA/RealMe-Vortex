using System.Collections.Generic;
using UnityEngine;

public enum TypeMenu { NONE, PAUSE, OPTIONS, INVENTORY, OTHER }

public class UIManager : MonoBehaviour, IInitialize
{
    public static UIManager instance;
    [SerializeField] private List<MenuParent> _menus;

    private CanvasGroup _canvasGroup;
    //private bool _paused;

    //private void OnEnable()
    //{
    //    InputManager.Pause += OnPause;
    //}

    //private void OnDisable()
    //{
    //    InputManager.Pause -= OnPause;
    //}

    public void InitializeAwake()
    {
        instance = this;
        TryGetComponent(out _canvasGroup);
    }  
  
    public void InitializeStart()
    {
        ChangeMenu(TypeMenu.NONE);
    }

    public void ChangeMenu(TypeMenu tp)
    {
        _menus.ForEach(n =>
        {
            StatusMenu(n.Canvas, n.Type == tp);
        }); 
    }

    public void CloseMenu(TypeMenu tp = TypeMenu.NONE) 
    {
        switch (tp)
        {
            case TypeMenu.NONE:
                _menus.ForEach(n =>
                {
                    StatusMenu(n.Canvas, false);
                });
                break;
           
            default:
                MenuParent mp = _menus.Find(n => n.Type == tp);
                StatusMenu(mp.Canvas, false  );
                break;
        } 
    }

    //public void OnPause()
    //{
    //    _paused = !_paused;

    //    Time.timeScale = _paused ? 0 : 1;

    //    StatusMenu(_canvasGroup, _paused);
    //}

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
