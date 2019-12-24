
public class NewGameMenu : Menu
{
    public InputField[] inputs;

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
