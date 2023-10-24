using UnityEngine;

public class GameFlow
{
    public EnumsData.GameFlow Status { get => _gameFlow; private set => _gameFlow = value; }
    private EnumsData.GameFlow _gameFlow;

    public GameFlow(EnumsData.GameFlow startFlow)
    {
        _gameFlow = startFlow;
    }
     

    public void UpdateFlow(EnumsData.GameFlow newState)
    {
        _gameFlow = newState;

    } 
}
