using UnityEngine;
using System;

public class Level1Manager : LevelManager
{
    private void Start()
    {
        actions.Add("Test", Test);
    }

    void Test(ButtonState state)
    {
        Debug.Log("HASDAS");
    }
}
