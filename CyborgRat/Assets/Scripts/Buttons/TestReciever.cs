using UnityEngine;

public class TestReciever : ButtonEventReceiver
{
    override public void RecieveSignal(ButtonState state)
    {
        Debug.Log("SDASDSADAS");
    }

}
