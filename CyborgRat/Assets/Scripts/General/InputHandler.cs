using UnityEngine;

public class InputHandler : MonoBehaviour
{

    public delegate void DirectionListener(float value);
    public DirectionListener horizontalAxisListener = delegate (float value) { };
    public DirectionListener verticalAxisListener = delegate (float value) { };

    public delegate void KeyListener();
    public KeyListener enterListener;
    public KeyListener upArrowListener;
    public KeyListener downArrowListener;

    void Update()
    {
        horizontalAxisListener(Input.GetAxisRaw("Horizontal"));
        verticalAxisListener(Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Return)) enterListener?.Invoke();
        if (Input.GetKeyDown(KeyCode.UpArrow)) upArrowListener?.Invoke();
        if (Input.GetKeyDown(KeyCode.DownArrow)) downArrowListener?.Invoke();
    }
}
