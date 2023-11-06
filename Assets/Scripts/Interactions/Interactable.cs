using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool blocked;

    public abstract void Interact();

    public abstract void ExitInteraction();

    public abstract void BlockInteraction(bool value);
}
