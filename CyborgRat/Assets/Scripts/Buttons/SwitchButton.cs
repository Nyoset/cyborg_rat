using UnityEngine;

public class SwitchButton : BaseButton
{
    ButtonState state = new ButtonState();
    public override ButtonState GetState() => state;

    protected override void ChangeState()
    {
        state.isPressed = !state.isPressed;
    }
}
