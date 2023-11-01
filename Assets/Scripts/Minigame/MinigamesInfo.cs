[System.Serializable]
public class MinigamesInfo
{
    public EnumsData.Minigame Minigame { get; private set; }
    public EnumsData.MiniGameStatus Status { get; private set; }

    public MinigamesInfo(EnumsData.Minigame minigame, EnumsData.MiniGameStatus status)
    {
        Minigame = minigame;
        Status = status;
    }

    public void ChangeStatus(EnumsData.MiniGameStatus newstatus)
    {
        Status = newstatus;
    }
}