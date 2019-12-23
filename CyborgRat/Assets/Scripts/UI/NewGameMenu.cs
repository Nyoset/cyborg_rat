
public class NewGameMenu : Menu
{
    override protected void Start()
    {
        actions = new ButtonAction[] { StartGame, Back };
        base.Start();
    }

    void StartGame()
    {
        string playerName = inputs[0]?.GetInputText();
        GameMaster.instance.StartGame(playerName);
    }

    void Back()
    {
        ActivateScreen<MainMenu>();
        Activate(false);
    }
}
