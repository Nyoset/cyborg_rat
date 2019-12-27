using UnityEngine;

public class Level1Manager : LevelManager
{
    private void Start()
    {
        actions.Add("Test", Test);
        actions.Add("Switch", Switch);
    }

    void Test(ButtonState state)
    {
        Debug.Log("Pressed");
    }

    void Switch(ButtonState state)
    {
        Debug.Log(state.isPressed);
    }

}
