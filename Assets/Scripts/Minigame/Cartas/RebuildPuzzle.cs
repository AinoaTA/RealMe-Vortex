using UnityEngine;
using PixelCrushers.DialogueSystem;
namespace Minigames
{
    public class RebuildPuzzle : Puzzle
    { 
        [SerializeField] private Transform[] _allPieces;
        [SerializeField] private Transform _gmMinigame;
        [SerializeField] private string _startConversation;
        [SerializeField] private string _endConversation;

        private Camera _cam;

        private void Start()
        {
            _cam = Camera.main;
        }

        public override void ClosePuzzle()
        {
            _gmMinigame.gameObject.SetActive(false);
        }

        public override void CompletedPuzzle()
        {
            Completed = true;

            if (_endConversation != "")
            {
                DialogueManager.StartConversation(_endConversation);
            }
        }

        public override void StartPuzzle()
        {
            if (_startConversation != "")
            {
                DialogueManager.StartConversation(_startConversation);
            }
            Vector2 pos = _gmMinigame.position;
            pos.x = _cam.transform.position.x;
            _gmMinigame.position = pos;

            _gmMinigame.gameObject.SetActive(true);
        }
    }
} 