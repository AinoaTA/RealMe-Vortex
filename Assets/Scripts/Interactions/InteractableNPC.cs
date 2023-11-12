using UnityEngine;
namespace NPC
{
    public class InteractableNPC : NearInteraction
    {
        [SerializeField] protected EnumsData.CharacterProfile _character;
        
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

            Debug.Log("NPC: " + _character);
            GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.IN_DIALOGUE);
            _interactionPanel.SetActive(false);

             //GameManager.instance.StartConver(_dialogue.conversation, true);
        }

        public override void ExitInteraction()
        {
            _interactionPanel.SetActive(_playerIsNear);
        }
    }
}