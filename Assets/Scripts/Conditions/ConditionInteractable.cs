using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionInteractable : GrabObject
{
    private Conditioner _conditioner;
    private bool _started;
    [SerializeField] private string _startConver;
    [SerializeField] private string _failedConver;
    protected override void Awake()
    {
        base.Awake();
        TryGetComponent(out _conditioner);
    }

    public override void Interact()
    {
        GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.IN_DIALOGUE);
        Debug.Log("int");
        if (_conditioner.CheckCondition())
        {
            Debug.Log("check");
            _interactionPanel.SetActive(false);

            if (!_started)
            {   //open the event at the end of the conversation. 
                //DialogueMethodsManager.CallBackOnEnd = delegate { _conditioner.DoEvent(); };

                _conditioner.DoEvent();
                //GameManager.instance.StartConver("Carta_good");
            }
            else
                _conditioner.DoEvent();

            _started = true;
        }
        else
        {
            GameManager.instance.StartConver(_failedConver, false);
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
