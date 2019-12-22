using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;

    Vector2 movement = Vector2.zero;

    void Start()
    {
        GameMaster.instance.inputHandler.horizontalAxisListener += HorizontalMovement;
        GameMaster.instance.inputHandler.verticalAxisListener += VerticalMovement;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void HorizontalMovement(float value)
    {
        movement.x = value;
    }

    void VerticalMovement(float value)
    {
        movement.y = value;
    }
}
