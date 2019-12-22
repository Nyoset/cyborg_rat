using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public delegate void DirectionListener(float value);
    public DirectionListener horizontalAxisListener = delegate (float value) { };
    public DirectionListener verticalAxisListener = delegate (float value) { };

    void Update()
    {
        horizontalAxisListener(Input.GetAxisRaw("Horizontal"));
        verticalAxisListener(Input.GetAxisRaw("Vertical"));
    }
}
