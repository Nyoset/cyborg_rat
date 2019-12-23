
public class NewGameMenu : Menu
{
    override protected void Start()
    {
        actions = new ButtonAction[] { StartGame };
        base.Start();
    }

    void StartGame()
    {
        string playerName = inputs[0]?.GetInputText();
        GameMaster.instance.StartGame(playerName);
    }

}
