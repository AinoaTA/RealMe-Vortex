
using System.Diagnostics;

namespace NPC
{
    public class ChuckDialogue : InteractableNPC
    {
        protected override void Awake()
        {
            base.Awake(); 
        }

        public override void Interact()
        { 
            GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.IN_DIALOGUE);
            _interactionPanel.SetActive(false);

            switch (BrokenHeart.Controller.instance.CurrentState())
            {
                case BrokenHeart.StateScene.NONE:
                    break;
                case BrokenHeart.StateScene.CIGARRILLOS_INTRO:
                    break;
                case BrokenHeart.StateScene.CIGARRILLOS_NOENCONTRADOS:
                    break;
                case BrokenHeart.StateScene.CIGARRILLOS_ENCONTRADO:
                    break;
                case BrokenHeart.StateScene.END_STATE:
                    break;
                default:
                    break;
            }
        }

        public override void ExitInteraction()
        {
            _interactionPanel.SetActive(_playerIsNear);
        }
    }
}