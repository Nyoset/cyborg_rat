using UnityEngine;

public class MainMenu : Menu
{
    override protected void Start()
    {
        actions = new ButtonAction[] { StartGame, LoadGame };
        base.Start();
    }

    void StartGame()
    {
        SceneLoader.StartGame();
    }

    void LoadGame()
    {
        Debug.Log("Load");
    }
}
