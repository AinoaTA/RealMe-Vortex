using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    public bool Completed { get => _completed; protected set => _completed = value; }
    [SerializeField] private bool _completed;

    public abstract void StartPuzzle();
    public abstract void ClosePuzzle();
    public abstract void CompletedPuzzle();
}