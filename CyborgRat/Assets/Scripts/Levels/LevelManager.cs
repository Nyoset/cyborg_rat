using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

public abstract class LevelManager : MonoBehaviour
{
    public delegate void ButtonEvent(ButtonState state);
    protected Dictionary<string, ButtonEvent> actions = new Dictionary<string, ButtonEvent> { };
    public Dictionary<string, ButtonEvent> effects = new Dictionary<string, ButtonEvent> { };

    protected virtual void Start()
    {
        List<ActionableButton> actionables = FindHelper.FindType<ActionableButton>();

        foreach (ActionableButton actionable in actionables)
        {
            string autoId = actionable.GetID();
            string methodName = autoId + "Effect";
            MethodInfo method = GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);

            if (method != null)
            {
                actions.Add(autoId, state => method.Invoke(this, new object[]{ state }));
            }
            else if (effects.ContainsKey(autoId))
            {
                actions.Add(autoId, state => effects[autoId](state));
            }
        }
    }

    public void RecieveButtonEvent(string buttonId, ButtonState state)
    {
        if (actions.ContainsKey(buttonId))
        {
            actions[buttonId](state);
        }
    }
}
