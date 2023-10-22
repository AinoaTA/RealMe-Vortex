using UnityEngine;
public class PointAndClick : Interactable
{
    public override void Interact() { }

    public virtual void OnMouseDown()
    {
        Interact();
    }
}