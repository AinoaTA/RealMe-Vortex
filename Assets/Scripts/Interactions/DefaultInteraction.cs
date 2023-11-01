using UnityEngine.Events;
using UnityEngine;

public class DefaultInteraction : NearInteraction
{ 
    [SerializeField] private UnityEvent _doInteract;

    public override void ExitInteraction()
    {
        throw new System.NotImplementedException();
    }

    public override void Interact()
    {
        Debug.Log("???");
        _doInteract?.Invoke();
    }
}