using UnityEngine;

public class GameMaster 
{
    const string initialPositionTag = "InitialPosition";
    const string menuTag = "Menu";

    public InputHandler inputHandler;

    public static GameMaster instance = null;
    public GameObject masterObject;

    public CameraController mainCamera;
    public PlayerController player;

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

        mainCamera = PrefabLoader.Load<CameraController>(Resource.Camera);

        if (!isSceneMenu())
        {
            player = PrefabLoader.Load<PlayerController>(Resource.Player);
            player.transform.position = GetSceneInitialPosition();
        }
    }

    bool isSceneMenu()
    {
        GameObject menuObject = GameObject.FindWithTag(menuTag);
        return menuObject;
    }

    Vector3 GetSceneInitialPosition()
    {
        GameObject initialPosition = GameObject.FindWithTag(initialPositionTag);
        if (initialPosition == null)
        {
            return Vector3.zero;
        }
        return initialPosition.transform.position;
    }
}