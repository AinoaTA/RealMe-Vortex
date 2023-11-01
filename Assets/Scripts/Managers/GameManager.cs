using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameFlow GameStatus { get; set; }

    public Inventory Inventory { get => _inventory; private set => _inventory = value; }
    [SerializeField] private Inventory _inventory;

    public List<MinigamesInfo> AllMinigames { get => _allMinigames; private set => _allMinigames = value; }
    [SerializeField]private List<MinigamesInfo> _allMinigames = new();

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

        for (int i = 0; i < (int)EnumsData.Minigame.END_ENUM; i++)
        {
            AllMinigames.Add(new((EnumsData.Minigame)i, EnumsData.MiniGameStatus.INCOMPLETED));
        }
    }

    private void Update()
    {
        Debug.Log("status game: " + GameStatus.Status);
    } 

    #region minigames check

    public void ChangeGameStatus(EnumsData.Minigame game, EnumsData.MiniGameStatus newStatus)
    {
        var g = AllMinigames.Find(n => n.Minigame == game);
        g.ChangeStatus(newStatus);
         
    }

    #endregion
}
