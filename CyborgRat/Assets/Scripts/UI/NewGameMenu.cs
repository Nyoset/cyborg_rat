using UnityEngine;

public class NewGameMenu : Menu
{
    override protected void Start()
    {
        actions = new ButtonAction[] { StartGame };
        base.Start();
    }

    void StartGame()
    {
        SceneLoader.StartGame();
    }

}
