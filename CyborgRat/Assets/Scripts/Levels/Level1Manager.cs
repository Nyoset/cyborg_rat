using UnityEngine;

public class Level1Manager : LevelManager
{
    private void Start()
    {
        actions.Add("DoorA", OpenADoors);
        actions.Add("DoorB", state => effects["DoorB"](state));
        actions.Add("DoorC", OpenCDoors);
        actions.Add("DoorD", OpenDDoors);
    }

    void OpenADoors(ButtonState state)
    {
        effects["DoorA"](state);
        effects["DoorA2"](state);
    }

    void OpenCDoors(ButtonState state)
    {
        effects["DoorC"](state);
        effects["DoorC2"](state);
        effects["DoorC3"](state);
    }

    void OpenDDoors(ButtonState state)
    {
        effects["DoorD"](state);
        effects["DoorD2"](state);
        effects["DoorD3"](state);
    }
}
