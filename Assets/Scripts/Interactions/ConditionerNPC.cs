using PixelCrushers.DialogueSystem;
using UnityEngine;

public class ConditionerNPC : NearInteraction
{
    [SerializeField] private EnumsData.CharacterProfile _character;

    //private DialogueSystemTrigger _dialogue;
    private Conditioner _conditioner;

    protected override void Awake()
    {
        base.Awake();
        TryGetComponent(out _conditioner);
        //TryGetComponent(out _dialogue);
    }

    public override void Interact()
    {
        Main.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.IN_DIALOGUE);
        if (_conditioner.CheckCondition())
        {
            _interactionPanel.SetActive(false);

            //open the event at the end of the conversation. 
            DialogueMethodsManager.CallBackOnEnd = delegate { _conditioner.DoEvent(); };
            DialogueManager.StartConversation("Carta_good");
        }
        else
        {
            DialogueManager.StartConversation("Carta_bad");
            Debug.Log("Te faltan cosas para poder hacer esto");
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
