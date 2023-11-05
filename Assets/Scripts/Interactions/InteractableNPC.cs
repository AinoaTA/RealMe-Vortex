using UnityEngine;
using PixelCrushers.DialogueSystem;

namespace NPC
{
    public class InteractableNPC : NearInteraction
    {
        [SerializeField] private EnumsData.CharacterProfile _character;

        private DialogueSystemTrigger _dialogue;

        protected override void Awake()
        {
            base.Awake();

            TryGetComponent(out _dialogue);
        }

        public override void Interact()
        {
            Debug.Log("NPC: " + _character);
            GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.IN_DIALOGUE);
            _interactionPanel.SetActive(false);

            GameManager.instance.StartConver(_dialogue.conversation, true);
        }

        public override void ExitInteraction()
        {
            _interactionPanel.SetActive(_playerIsNear);
        }
    }
}