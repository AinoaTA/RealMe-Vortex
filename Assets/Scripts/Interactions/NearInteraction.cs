using UnityEngine;

/// <summary>
/// Inheritance class.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class NearInteraction : Interactable
{
    protected ReadInteraction _interaction = new();
    protected GameObject _interactionPanel;

    protected bool _playerIsNear;

    protected virtual void Awake()
    {
        _interactionPanel = _interaction.GetInteractionObject("interaction");
        _interactionPanel.transform.position = transform.position + Vector3.up;
        _interactionPanel.transform.SetParent(transform);
        _interactionPanel.SetActive(false);

        TryGetComponent(out Collider2D _col);
        _col.isTrigger = true;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (blocked) return;

        if (collision.CompareTag("Player"))
        {
            _playerIsNear = true;
            _interactionPanel.SetActive(true);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (blocked && !_interactionPanel.activeSelf) return;

        if (collision.CompareTag("Player"))
        {
            _playerIsNear = false;
            _interactionPanel.SetActive(false);
        }
    }

    public override void ExitInteraction()
    {
        throw new System.NotImplementedException();
    }

    public override void Interact()
    {
        if (blocked)
        {
            ExitInteraction();
            return;
        }
    }
}