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
                    GameManager.instance.StartConver("BrokenHeart/Chuck_Intro", true);
                  
                    break;
                case BrokenHeart.StateScene.CIGARRILLOS_INTRO:
            
                case BrokenHeart.StateScene.MUST_ELEK_TALK:
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