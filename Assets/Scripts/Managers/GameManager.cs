using PixelCrushers.DialogueSystem;
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
     
    [SerializeField] private GameObject _npcDialogue;
    [SerializeField] private GameObject _oniricDialogue;

    public bool MustFollowPlayer { get=>_mustFollow; set => _mustFollow = value; }
    [SerializeField] private bool _mustFollow;

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
        if(GameStatus!=null)
        Debug.Log("status game: " + GameStatus.Status);
    } 

    #region minigames check

    public void ChangeMinigameStatus(EnumsData.Minigame game, EnumsData.MiniGameStatus newStatus)
    {
        var g = AllMinigames.Find(n => n.Minigame == game);
        g.ChangeStatus(newStatus);
         
    }

    #endregion

    public void StartConver(string converName, bool npcDialogue=false)
    {
        GameStatus.UpdateFlow(EnumsData.GameFlow.IN_DIALOGUE); 

        DialogueManager.UseDialogueUI(npcDialogue ? _npcDialogue : _oniricDialogue);
        DialogueManager.StopConversation();
        DialogueManager.StartConversation(converName);
    } 
}
