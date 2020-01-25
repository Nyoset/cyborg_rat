using UnityEngine;

abstract public class ButtonEventReceiver : MonoBehaviour
{
    public string recieverId;

    private void Start()
    {
        GameMaster.instance.currentLevelManager.effects.Add(recieverId, RecieveSignal);
    }

    abstract public void RecieveSignal(ButtonState state);

    private void OnDestroy()
    {
        if (GameMaster.instance.currentLevelManager.effects.ContainsKey(recieverId))
        {
            GameMaster.instance.currentLevelManager.effects.Remove(recieverId);
        }
    }
}
