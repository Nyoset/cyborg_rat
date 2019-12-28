using UnityEngine;
using System.Collections.Generic;

public abstract class LevelManager : MonoBehaviour
{
    public delegate void ButtonEvent(ButtonState state);
    protected Dictionary<string, ButtonEvent> actions = new Dictionary<string, ButtonEvent> { };
    public Dictionary<string, ButtonEvent> effects = new Dictionary<string, ButtonEvent> { };

    public void RecieveButtonEvent(string buttonId, ButtonState state)
    {
        if (actions.ContainsKey(buttonId))
        {
            actions[buttonId](state);
        }
    }
}
