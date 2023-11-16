using UnityEngine;

namespace BrokenHeart
{
    public class ElekDialogue : NPC.InteractableNPC
    {
        public override void Interact()
        {
            if (blocked)
            {
                ExitInteraction();
                return;
            }

            GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.IN_DIALOGUE);
            _interactionPanel.SetActive(false);

            switch (Controller.instance.CurrentState())
            { 
                case StateScene.MUST_ELEK_TALK:
                    GameManager.instance.StartConver("BrokenHeart/Elek_Talking1", true);
                    break;
                case StateScene.GIVE_CIGARRILLOS:
                    break;
                case StateScene.FIND_PILLS:
                    break;
                case StateScene.FOUND_PILLS:
                    break;
                case StateScene.FIND_MULETA:
                    break;
                case StateScene.ELEK_TALKTO_LOGAN:
                    GameManager.instance.StartConver("BrokenHeart/Elek_Talking2", true);
                    break; 
                case StateScene.ELEK_COMES_TO_HELP:
                    break;
                case StateScene.END_STATE:
                    break;
                default:
                    break;
            }
        }
    }
}