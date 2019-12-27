using UnityEngine;

public class SimpleButton : BaseButton
{
    SimpleButtonState state = new SimpleButtonState();
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

public class SimpleButtonState : ButtonState
{
    public bool isPressed;
}