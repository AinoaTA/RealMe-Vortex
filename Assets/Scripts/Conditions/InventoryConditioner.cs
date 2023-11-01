using UnityEngine.Events;
using UnityEngine;

public class InventoryConditioner : Conditioner
{
    [Space(20)]
    [SerializeField] private UnityEvent onComplete;
    [SerializeField] private InventoryCondition _requiredObjects;

    private CheckerCondition _checker = new();
    private bool _enabled = false;

    public override bool CheckCondition()
    {
        bool b = _checker.CheckCondition(_requiredObjects.itemsRequired);
        _enabled = b;

        return _enabled;
    }

    public override void DoEvent()
    {
        if (_enabled)
            onComplete?.Invoke();
    }
}