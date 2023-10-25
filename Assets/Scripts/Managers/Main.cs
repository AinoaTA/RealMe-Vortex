using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main instance;

    public GameFlow GameStatus { get; set; }
    public Inventory Inventory { get => _inventory; private set => _inventory = value; }

    [SerializeField] private Inventory _inventory;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        GameStatus = new(EnumsData.GameFlow.GAMEPLAY);
    }
}
