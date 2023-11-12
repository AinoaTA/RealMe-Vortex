using UnityEngine;
using PixelCrushers.DialogueSystem;
using System.Linq;
using System.Collections;
using UnityEngine.Events;

namespace Minigames.Rebuild
{
    public class RebuildPuzzle : Puzzle
    {
        [SerializeField] private Piece[] _allPieces;
        [SerializeField] private Transform _gmMinigame;
        [SerializeField] private string _startConversation;
        [SerializeField] private string _endConversation;
        [SerializeField] private Item[] _itemsGiven;
        [SerializeField] private Item[] _itemsToRemove;
        [Space(20)]
        [SerializeField] private UnityEvent _onCompleted;
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

        public override void ClosePuzzle()
        {
            _gmMinigame.gameObject.SetActive(false);

            GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.GAMEPLAY);
        }

        public override void CompletedPuzzle()
        {
            Completed = true;

            GameManager.instance.ChangeMinigameStatus(minigame, EnumsData.MiniGameStatus.COMPLETED);

            if (_endConversation != "")
            {
                DialogueManager.StartConversation(_endConversation);
            }

            StartCoroutine(OnCompleteAnimation());

            if (_itemsGiven.Length != 0)
            {
                _itemsGiven.ToList().ForEach(n =>
                {
                    Inventory.instance.AddItem(n, 1);
                });
            }

            if (_itemsToRemove.Length != 0)
            { 
                for (int i = 0; i < _itemsToRemove.Length; i++)
                {
                    Inventory.instance.RemoveItem(_itemsToRemove[i], 1);
                }
            }
            FMODUnity.RuntimeManager.PlayOneShot(_completedSound);
            _onCompleted?.Invoke();
        }

        public override void StartPuzzle()
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

        public override void ResetPuzzle()
        {
            throw new System.NotImplementedException();
        }
    }
}