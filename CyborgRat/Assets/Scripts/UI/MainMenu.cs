using UnityEngine;

public class MainMenu : Menu
{
    override protected void Start()
    {
        actions = new ButtonAction[] { GoToNewGameMenu, LoadGame };
        base.Start();
    }

    void GoToNewGameMenu()
    {
        ActivateScreen<NewGameMenu>();
        Activate(false);
    }

    void LoadGame()
    {
        Debug.Log("Load");
    }
}
