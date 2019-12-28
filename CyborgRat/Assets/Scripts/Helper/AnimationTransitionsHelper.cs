using System.ComponentModel;
using UnityEngine;

enum Transition
{
    [Description("openDoor")]
    OpenDoor,
    [Description("closeDoor")]
    CloseDoor,
}

static class AnimationTransitionsHelper
{
    public static void AnimateTrigger(this Animator animator, Transition transition)
    {
        animator.SetTrigger(transition.Description());
    }
}
