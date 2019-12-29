using UnityEngine;

abstract public class BaseButton : MonoBehaviour, ActionableButton
{
    Collider2D buttonCollider;
    Animator animator;
    SpriteRenderer colorSprite;

    public string id;
    public Color buttonColor;

    static Color defaultColor = new Color(0, 0, 0, 0);

    public abstract ButtonState GetState();
    protected abstract void ChangeState();

    protected virtual bool ShouldNotify()
    {
        return true;
    }

    protected virtual void Awake()
    {
        buttonCollider = gameObject.GetComponent<Collider2D>();
        animator = gameObject.GetComponent<Animator>();
        colorSprite = gameObject.FindComponentInChildWithTag<SpriteRenderer>(Tag.Colorable);
        if (buttonColor != defaultColor) colorSprite.color = buttonColor;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (ShouldNotify())
        {
            ApplyChanges();
        }
    }  

    protected virtual void ApplyChanges()
    {
        animator.AnimateTrigger(Transition.PressButton);
        ChangeState();
        GameMaster.instance.currentLevelManager.RecieveButtonEvent(id, GetState());
    }

    void OnValidate()
    {
        Awake();
    }
}

public interface ActionableButton
{
    ButtonState GetState();
}

public class ButtonState {
    public bool isPressed;
}
