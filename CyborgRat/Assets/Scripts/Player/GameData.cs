[System.Serializable]
public class GameData 
{
    public string playerName;
    public int level;

    public GameData(string playerName)
    {
        level = 0;
        this.playerName = playerName;
    }
}
