using UnityEngine;

public class DialogueInteraction : NearInteraction
{
    [SerializeField] protected string _dialogue;

    public override void ExitInteraction()
    {
        GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.GAMEPLAY);
        //throw new System.NotImplementedException();
    }

    public override void Interact()
    {
        if (blocked)
        {
            ExitInteraction();
            return;
        }

        FMODUnity.RuntimeManager.PlayOneShot(_pathSound);
        GameManager.instance.StartConver(_dialogue);
    }
}