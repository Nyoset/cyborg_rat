using UnityEngine;

public class DoorReceiver : ButtonEventReceiver
{
    Animator myAnimator;

    public bool inverted;

    private bool _open;
    public bool open
    {
        get
        {
            return _open;
        }
        set
        {
            _open = value;
            UpdateDoorState();
        }
    } 

    private void Awake()
    {
        myAnimator = gameObject.GetComponent<Animator>();
        open = inverted;
    }

    void UpdateDoorState()
    {
        myAnimator.AnimateBool(Transition.DoorOpen, open);
    }

    override public void RecieveSignal(ButtonState state)
    {
        open = inverted ^ state.isPressed;
    }
}
