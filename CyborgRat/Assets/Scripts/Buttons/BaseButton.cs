using UnityEngine;

abstract public class BaseButton : MonoBehaviour, ActionableButton
{
    Collider2D buttonCollider;
    Animator animator;

    public string id;
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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (ShouldNotify())
        {
            animator.SetTrigger("press");
            ChangeState();
            GameMaster.instance.currentLevelManager.RecieveButtonEvent(id, GetState());
        }
    }  
}

public interface ActionableButton
{
    ButtonState GetState();
}

public class ButtonState {
    public bool isPressed;
}
