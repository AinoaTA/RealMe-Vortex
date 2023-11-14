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
            
                case BrokenHeart.StateScene.GIVE_CIGARRILLOS:
                    GameManager.instance.StartConver("BrokenHeart/Chuck_GiveCigarrillos", true);
                    break;

                case BrokenHeart.StateScene.FOUND_MULETA: 
                    GameManager.instance.StartConver("BrokenHeart/Chuck_GiveMuleta", true);
                    break;
                case BrokenHeart.StateScene.END_STATE:
                    break;
                default:
                    break;
            }

            BrokenHeart.Controller.instance.NextState();
        }

        public override void ExitInteraction()
        {
            _interactionPanel.SetActive(_playerIsNear);
        }
    }
}