using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public float speed = 5f;

    Vector2 movement = Vector2.zero;
    Vector2 orientation = Vector2.down;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        GameMaster.instance.inputHandler.horizontalAxisListener += HorizontalMovement;
        GameMaster.instance.inputHandler.verticalAxisListener += VerticalMovement;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        animator.SetFloat("speed", movement.sqrMagnitude);
        animator.SetFloat("horizontal_orientation", orientation.x);
        animator.SetFloat("vertical_orientation", orientation.y);
    } 

    void HorizontalMovement(float value)
    {
        movement.x = value;
        if (value != 0)
        {
            orientation.x = value;
            orientation.y = 0;
        }
    }

    void VerticalMovement(float value)
    {
        movement.y = value;
        if (value != 0)
        {
            orientation.x = 0;
            orientation.y = value;
        }
    }
}
