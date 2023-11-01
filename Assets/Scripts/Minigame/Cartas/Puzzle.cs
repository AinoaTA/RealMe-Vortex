using System.Collections;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    public EnumsData.Minigame minigame;

    public bool Completed { get => _completed; protected set => _completed = value; }
    [SerializeField] private bool _completed;

    public System.Action OnCompleteMinigame;

    protected abstract void StartPuzzle();
    protected abstract void ClosePuzzle();
    protected abstract void CompletedPuzzle();
    protected abstract void ResetPuzzle();

    protected virtual IEnumerator OnCompleteAnimation()
    {
        yield return null;
    }
}