using PixelCrushers.DialogueSystem;
using UnityEngine;

public class ConditionerNPC : NearInteraction
{
    [SerializeField] private EnumsData.CharacterProfile _character;

    private Conditioner _conditioner;
    private bool _started;

    protected override void Awake()
    {
        base.Awake();
        TryGetComponent(out _conditioner);
    }

    public override void Interact()
    {
        GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.IN_DIALOGUE);
        DialogueManager.StopConversation();

        if (_conditioner.CheckCondition())
        {
            _interactionPanel.SetActive(false);

            if (!_started)
            {   //open the event at the end of the conversation. 
                DialogueMethodsManager.CallBackOnEnd = delegate { _conditioner.DoEvent(); };
                DialogueManager.StartConversation("Carta_good");
            }
            else
                _conditioner.DoEvent();

            _started = true;
        }
        else
        {
            DialogueManager.StartConversation("Carta_bad");
        }
    }

    public void DoCondition()
    {
        _conditioner.DoEvent();
    }

    public override void ExitInteraction()
    {
        _interactionPanel.SetActive(_playerIsNear);
    }
}