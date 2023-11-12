using System.Collections;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    public EnumsData.Minigame minigame;

    public bool Completed { get => _completed; protected set => _completed = value; }
    [SerializeField] private bool _completed;

    public System.Action OnCompleteMinigame;
   [SerializeField] protected string _completedSound;

    public abstract void StartPuzzle();
    public abstract void ClosePuzzle();
    public abstract void CompletedPuzzle();
    public abstract void ResetPuzzle();

    protected virtual IEnumerator OnCompleteAnimation()
    {
        yield return null;
    }
}