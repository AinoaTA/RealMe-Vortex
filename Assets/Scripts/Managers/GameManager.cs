using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public SceneSettings SceneSettings { get => _sceneSettings; }
    [SerializeField] private SceneSettings _sceneSettings;
     
    public UIManager UIManager { get => _uiManager; }
    [SerializeField] private UIManager _uiManager;

    private void Awake()
    {
        Instance = this; 
    }
}