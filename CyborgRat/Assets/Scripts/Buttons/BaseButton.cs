using UnityEngine;

abstract public class BaseButton : MonoBehaviour, ActionableButton
{
    Collider2D buttonCollider;
    Animator animator;

    [SerializeField]
    string id;
    public abstract ButtonState GetState();
    protected abstract void ChangeState();

    protected virtual void Awake()
    {
        buttonCollider = gameObject.GetComponent<Collider2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("press");
        ChangeState();
        GameMaster.instance.currentLevelManager.RecieveButtonEvent(id, GetState());
    }  
}

public interface ActionableButton
{
    ButtonState GetState();
}

abstract public class ButtonState { }
