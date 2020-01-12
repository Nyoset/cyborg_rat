using System.ComponentModel;
using UnityEngine;

enum Transition
{
    [Description("doorOpen")]
    DoorOpen,

    [Description("pressButton")]
    PressButton,
}

static class AnimationTransitionsHelper
{
    public static void AnimateTrigger(this Animator animator, Transition transition)
    {
        animator.SetTrigger(transition.Description());
    }

    public static void AnimateBool(this Animator animator, Transition transition, bool value)
    {
        animator.SetBool(transition.Description(), value);
    }
}
