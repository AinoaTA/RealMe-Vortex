using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main instance;

    public GameFlow GameStatus { get; set; }

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
