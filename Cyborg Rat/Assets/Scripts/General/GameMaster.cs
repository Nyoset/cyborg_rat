using UnityEngine;

public class GameMaster 
{
    public InputHandler inputHandler;

    public static GameMaster instance = null;
    public GameObject masterObject;
    public Camera mainCamera;
    public GameObject player;

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

        mainCamera = PrefabLoader.Load<Camera>(Resource.Camera);
        player = PrefabLoader.Load<GameObject>(Resource.Player);
    }
}