using UnityEngine;

public abstract class LevelManager : MonoBehaviour
{

    public void RecieveButtonEvent(string buttonId, ButtonState state)
    {
        Debug.Log("HEY");
    }

}
