using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureButton : BaseButton
{
    ButtonState state = new ButtonState();
    public override ButtonState GetState() => state;

    protected override void ChangeState()
    {
        state.isPressed = !state.isPressed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ApplyChanges();
    }
}
