using UnityEngine;

public class InventoryDot : MonoBehaviour
{
    [SerializeField] private GameObject _dot;

    public delegate void DelegateDotShow(bool value);
    public static DelegateDotShow OnShow;


    private void OnEnable()
    {
        OnShow += ShowDot;
    }

    private void OnDisable()
    {
        OnShow -= ShowDot;
    }

    private void Start()
    {
        ShowDot(false);
    }

    public void ShowDot(bool show)
    {
        _dot.SetActive(show);
    }
}