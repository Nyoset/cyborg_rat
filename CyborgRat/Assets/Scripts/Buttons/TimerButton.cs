using UnityEngine;
using System.Collections;

public class TimerButton : BaseButton
{
    ButtonState state = new ButtonState();
    public override ButtonState GetState() => state;

    public float timeLimit = 5f;
    private float currentTimer;

    protected override void ChangeState()
    {
        state.isPressed = !state.isPressed;
    }

    protected override bool ShouldNotify()
    {
        return !state.isPressed || (state.isPressed && currentTimer <= 0);
    }

    private void FixedUpdate()
    {
        if (currentTimer > 0) currentTimer -= Time.fixedDeltaTime;
        if (currentTimer <= 0 && state.isPressed)
        {
            ApplyChanges();
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        currentTimer = timeLimit;
    }
}
