using UnityEngine;

public class LoadMenu : Menu
{
    protected override void Start()
    {
        SaveSystem.ReadAllSaveGames();
        base.Start();
    }
}
