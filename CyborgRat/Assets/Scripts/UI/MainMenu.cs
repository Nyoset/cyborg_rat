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
        Debug.Log("Play");
    }

    void LoadGame()
    {
        Debug.Log("Load");
    }
}
