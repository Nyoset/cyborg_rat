using UnityEngine;

public class Level1Manager : LevelManager
{
    private void Start()
    {
        actions.Add("Test", state => effects["TestReciever"](state));
        actions.Add("Switch", state => effects["TestReciever"](state));
    }

}
