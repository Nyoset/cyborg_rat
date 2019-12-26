using UnityEngine;

public class BaseButton : MonoBehaviour
{
    Collider2D buttonCollider;
    Animator animator;

    protected private void Awake()
    {
        buttonCollider = gameObject.GetComponent<Collider2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    protected void Start()
    {
        
    }

    protected void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("press");
    }
}
