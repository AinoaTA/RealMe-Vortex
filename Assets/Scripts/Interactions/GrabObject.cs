using UnityEngine;

public class GrabObject : NearInteraction
{
    [SerializeField] private Item _item;
    [SerializeField] private int _quantity;

    public delegate void DelegateGrab(Item item, int quantity);
    public static DelegateGrab OnGrab;

    public override void ExitInteraction()
    {
        throw new System.NotImplementedException();
    }

    public override void Interact()
    {
        if (_playerIsNear)
            Grab();
    }

    protected virtual void Grab()
    {
        Debug.Log("grabbing");

        OnGrab?.Invoke(_item, _quantity);
        gameObject.SetActive(false);
    }
}