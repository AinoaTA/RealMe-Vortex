using UnityEngine;

public class DialogueInteraction : NearInteraction
{
      public string _dialogue;
    [SerializeField] private bool _npcTalk;

    public override void ExitInteraction()
    {
        GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.GAMEPLAY);
        //throw new System.NotImplementedException();
    }

    public override void Interact()
    {
        //if (blocked)
        //{
        //    ExitInteraction();
        //    return;
        //}

        //FMODUnity.RuntimeManager.PlayOneShot(_pathSound);
        base.Interact();
        GameManager.instance.StartConver(_dialogue,_npcTalk);
    }
}