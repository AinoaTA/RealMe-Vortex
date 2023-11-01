using UnityEngine;

public class MenuParent : MonoBehaviour
{
    public TypeMenu Type { get => _typeMenu; }
    [SerializeField] private TypeMenu _typeMenu;

    public CanvasGroup Canvas { get => _canvas; private set => _canvas = value; }
    private CanvasGroup _canvas;

    private void Awake()
    {
        TryGetComponent(out _canvas);

        Debug.Log(_canvas);
    }

    protected virtual void Open() { }

    protected virtual void Close()
    {
        GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.GAMEPLAY);
        UIManager.instance.CloseMenu(Type);
    }

}