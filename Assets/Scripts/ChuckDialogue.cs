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
                 
                case BrokenHeart.StateScene.GIVE_CIGARRILLOS:
                    GameManager.instance.StartConver("BrokenHeart/Chuck_GiveCigarrillos", true);
                    break;

                case BrokenHeart.StateScene.FOUND_PILLS:

                    GameManager.instance.StartConver("BrokenHeart/Chuck_GivePastilla", true);
                    break;
                case BrokenHeart.StateScene.FOUND_MULETA:
                    GameManager.instance.StartConver("BrokenHeart/Chuck_GiveMuleta", true);
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