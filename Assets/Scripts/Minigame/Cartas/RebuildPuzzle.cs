using UnityEngine;
using PixelCrushers.DialogueSystem;
using System.Linq;

namespace Minigames.Rebuild
{
    public class RebuildPuzzle : Puzzle
    {
        [SerializeField] private Piece[] _allPieces;
        [SerializeField] private Transform _gmMinigame;
        [SerializeField] private string _startConversation;
        [SerializeField] private string _endConversation;
        [SerializeField] private bool _miniGameCompleted = false;

        private Camera _cam;

        private void OnEnable()
        {
            Piece.OnUpdatePiece += CheckAnswers;
        }

        private void OnDisable()
        {
            Piece.OnUpdatePiece -= CheckAnswers;
        }

        private void CheckAnswers()
        {
            Debug.Log("updating");
            for (int i = 0; i < _allPieces.Length; i++)
            {
                if (!_allPieces[i].Complete)
                {
                    _miniGameCompleted = false;
                    return;
                }
            }

            Debug.Log("Minigame COMPLETED!!!");
            _miniGameCompleted = true;  
        }

        private void Start()
        {
            _cam = Camera.main;
            _gmMinigame.gameObject.SetActive(false);

        }

        public override void ClosePuzzle()
        {
            _gmMinigame.gameObject.SetActive(false);

            Main.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.GAMEPLAY);
        }

        public override void CompletedPuzzle()
        {
            Completed = true;

            if (_endConversation != "")
            {
                DialogueManager.StartConversation(_endConversation);
            }

            ClosePuzzle();
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