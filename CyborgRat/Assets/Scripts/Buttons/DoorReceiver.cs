using UnityEngine;
using UnityEditor;

public class DoorReceiver : ButtonEventReceiver
{
    Animator myAnimator;
    SpriteRenderer spriteRenderer;

    public bool inverted;
    public bool parallel;

    void OnValidate()
    {
        EditorApplication.delayCall += this.CallbackEditor(ChangeSprite);
    }

    void ChangeSprite()
    {
        Sprite sprite = ResourceLoader.Load(parallel ? SpriteFile.ParallelDoor : SpriteFile.PerpendicularDoor);
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }

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
        ChangeSprite();
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
