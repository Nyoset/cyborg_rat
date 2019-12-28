using UnityEngine;

public class InvertedDoorReceiver : ButtonEventReciever
{
    Animator myAnimator;

    private void Awake()
    {
        myAnimator = gameObject.GetComponent<Animator>();
        myAnimator.AnimateTrigger(Transition.OpenDoor);
    }

    override public void RecieveSignal(ButtonState state)
    {
        myAnimator.AnimateTrigger(state.isPressed ? Transition.CloseDoor : Transition.OpenDoor);
    }
}
