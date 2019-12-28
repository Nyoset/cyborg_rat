﻿using UnityEngine;

public class DoorReciever : ButtonEventReciever
{
    Animator myAnimator;

    private void Awake()
    {
        myAnimator = gameObject.GetComponent<Animator>();
    }

    override public void RecieveSignal(ButtonState state)
    {
        myAnimator.AnimateTrigger(state.isPressed ? Transition.OpenDoor : Transition.CloseDoor);
    }
}
