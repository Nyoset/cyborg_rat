using UnityEngine;

public class SimpleButton : BaseButton
{
    SimpleButtonState state = new SimpleButtonState();
    public override ButtonState GetState() => state;

    protected override void ChangeState()
    {
        state.isPressed = true;
    }
}

public class SimpleButtonState : ButtonState
{
    public bool isPressed;
}