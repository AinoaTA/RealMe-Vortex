using UnityEngine;
using PixelCrushers.DialogueSystem;
using System.Linq;
using System.Collections;

namespace Minigames.Rebuild
{
    public class RebuildPuzzle : Puzzle
    {
        [SerializeField] private Piece[] _allPieces;
        [SerializeField] private Transform _gmMinigame;
        [SerializeField] private string _startConversation;
        [SerializeField] private string _endConversation;

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
            if (Completed) return;

            for (int i = 0; i < _allPieces.Length; i++)
            {
                if (!_allPieces[i].Complete)
                {
                    Completed = false;
                    return;
                }
            }

            _allPieces.ToList().ForEach(x => x.Block(true));

            Completed = true;

            CompletedPuzzle();
        }

        private void Start()
        {
            _cam = Camera.main;
            _gmMinigame.gameObject.SetActive(false);
        }

        protected override void ClosePuzzle()
        {
            _gmMinigame.gameObject.SetActive(false);

            GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.GAMEPLAY);
        }

        protected override void CompletedPuzzle()
        {
            Completed = true;

            GameManager.instance.ChangeGameStatus(minigame, EnumsData.MiniGameStatus.COMPLETED);

            if (_endConversation != "")
            {
                DialogueManager.StartConversation(_endConversation);
            }

            StartCoroutine(OnCompleteAnimation());
        }

        protected override void StartPuzzle()
        {
            if (Completed)
            {
                ClosePuzzle();
                return;
            }

            if (_startConversation != "")
            {
                DialogueManager.StartConversation(_startConversation);
            }
            Vector2 pos = _gmMinigame.position;
            pos.x = _cam.transform.position.x;
            _gmMinigame.position = pos;

            _gmMinigame.gameObject.SetActive(true);
        }

        protected override IEnumerator OnCompleteAnimation()
        {
            yield return new WaitForSeconds(1);
            OnCompleteMinigame?.Invoke();
            ClosePuzzle();
        }

        protected override void ResetPuzzle()
        {
            throw new System.NotImplementedException();
        }
    }
}