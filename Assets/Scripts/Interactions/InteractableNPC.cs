using UnityEngine;
namespace NPC
{
    public class InteractableNPC : NearInteraction
    {
        [SerializeField] protected EnumsData.CharacterProfile _character;
        [SerializeField] protected string _dialogue;
        protected override void Awake()
        {
            base.Awake();
        }

        public override void Interact()
        {
            if (blocked)
            {
                ExitInteraction();
                return;
            }
             
            GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.IN_DIALOGUE);
            _interactionPanel.SetActive(false);

            GameManager.instance.StartConver(_dialogue, true);
        }

        public override void ExitInteraction()
        {
            _interactionPanel.SetActive(_playerIsNear);
        }
    }
}