using UnityEngine;

public class Level1Manager : LevelManager
{

    void DoorAEffect(ButtonState state)
    {
        effects["DoorA"](state);
        effects["DoorA2"](state);
    }

    void DoorCEffect(ButtonState state)
    {
        effects["DoorC"](state);
        effects["DoorC2"](state);
        effects["DoorC3"](state);
    }

    void DoorDEffect(ButtonState state)
    {
        effects["DoorD"](state);
        effects["DoorD2"](state);
        effects["DoorD3"](state);
    }
}
