using UnityEngine;

public class GameMaster 
{
    public InputHandler inputHandler;

    public static GameMaster instance = null;
    public GameObject masterObject;

    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        Instance();
    }

    public static GameMaster Instance()
    {
        if (instance == null)
        {
            instance = new GameMaster();
        }
        return instance;
    }

    public GameMaster()
    {
        Debug.Log("Initializing GameMaster");
        masterObject = new GameObject();
        masterObject.name = "MasterObject";
        inputHandler = masterObject.AddComponent<InputHandler>();
    }
}