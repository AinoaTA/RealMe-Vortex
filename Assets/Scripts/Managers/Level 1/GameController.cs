using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public SceneSettings SceneSettings { get => _sceneSettings; }
    [SerializeField] private SceneSettings _sceneSettings;

    public UIManager UIManager { get => _uiManager; }
    [SerializeField] private UIManager _uiManager;

    public Interactable CurrentInUse { get; set; }

    public void ExitCurrentInteraction()
    {
        CurrentInUse.ExitInteraction();
        GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.GAMEPLAY);
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.GAMEPLAY);
    }
}