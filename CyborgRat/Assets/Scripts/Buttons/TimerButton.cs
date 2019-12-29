using UnityEngine;
using System.Collections;

public class TimerButton : BaseButton
{
    ButtonState state = new ButtonState();
    public override ButtonState GetState() => state;

    public float timeLimit = 5f;
    bool timerActive;

    protected override void ChangeState()
    {
        state.isPressed = !state.isPressed;
    }

    protected override bool ShouldNotify()
    {
        return !timerActive;
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        StartCoroutine(Timer());
        timerActive = true;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeLimit);
        if (timerActive)
        {
            ApplyChanges();
            timerActive = false;
        }
    }
}
