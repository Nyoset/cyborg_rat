using UnityEngine;

public class SimpleButton : BaseButton
{
    ButtonState state = new ButtonState();
    public override ButtonState GetState() => state;

    protected override void ChangeState()
    {
        state.isPressed = true;
    }

    protected override bool ShouldNotify()
    {
        return !state.isPressed;
    }

}
