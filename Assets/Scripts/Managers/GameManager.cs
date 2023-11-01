using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public SceneSettings SceneSettings { get => _sceneSettings; }
    [SerializeField] private SceneSettings _sceneSettings;
     
    public UIManager UIManager { get => _uiManager; }
    [SerializeField] private UIManager _uiManager;

    public Interactable CurrentInUse { get; set; }

    public void ExitCurrentInteraction() 
    {
        CurrentInUse.ExitInteraction();
        Main.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.GAMEPLAY);
    }

    private void Awake()
    {
        Instance = this; 
    }

    private void Start()
    {
        Main.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.GAMEPLAY);
    }

    
}