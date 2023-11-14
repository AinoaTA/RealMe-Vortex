using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : NearInteraction
{
    private Conditioner _conditioner;
    private bool _started;

    [SerializeField] private string _noCompletedSound;
    [SerializeField] private string _closeDoor = "Puerta";
    protected override void Awake()
    {
        base.Awake();
        TryGetComponent(out _conditioner);
    }

    public override void Interact()
    {
        GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.IN_DIALOGUE);

        if (_conditioner.CheckCondition())
        {
            _interactionPanel.SetActive(false);

            if (!_started)
            {   //open the event at the end of the conversation. 
                //DialogueMethodsManager.CallBackOnEnd = delegate { _conditioner.DoEvent(); };
                //FadesController.Instance.FadeIn();
                _conditioner.DoEvent();

                FMODUnity.RuntimeManager.PlayOneShot(_pathSound);
                //GameManager.instance.StartConver("Carta_good");
            }
            else
                _conditioner.DoEvent();

            _started = true;
        }
        else
        {
            if (_closeDoor != "")
                GameManager.instance.StartConver(_closeDoor, true);

            FMODUnity.RuntimeManager.PlayOneShot(_noCompletedSound);
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
