using UnityEngine;

public class TestReciever : ButtonEventReciever
{
    override public void RecieveSignal(ButtonState state)
    {
        Debug.Log("SDASDSADAS");
    }

}
