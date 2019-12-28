using UnityEngine;

public class Level1Manager : LevelManager
{
    private void Start()
    {
        actions.Add("DoorA", state => effects["DoorA"](state));
        actions.Add("DoorB", state => effects["DoorB"](state));
        actions.Add("DoorC", OpenCDoors);
        actions.Add("DoorD", OpenDDoors);
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
