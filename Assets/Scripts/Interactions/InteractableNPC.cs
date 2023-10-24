using UnityEngine;

namespace NPC
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class InteractableNPC : Interactable
    {
        [SerializeField] private EnumsData.CharacterProfile _character;

        private ReadInteraction _interaction = new();
        private GameObject _interactionPanel;

        private void Awake()
        {
            _interactionPanel = _interaction.GetInteractionObject("interaction");
            _interactionPanel.transform.position = transform.position + Vector3.up;
            _interactionPanel.SetActive(false);
        }

        public override void Interact()
        {
            Debug.Log("NPC: " + _character);
            Main.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.INTERACTING);
            _interactionPanel.SetActive(false); 
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                _interactionPanel.SetActive(true);
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                _interactionPanel.SetActive(false);
        }
    }
}