using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

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

        masterObject = new GameObject { name = "MasterObject" };
        GameObject.DontDestroyOnLoad(masterObject);

        inputHandler = masterObject.AddComponent<InputHandler>();

        SceneManager.sceneLoaded += OnSceneLoaded;
        OnSceneLoaded(SceneManager.GetSceneByBuildIndex(0), LoadSceneMode.Single);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        mainCamera = PrefabLoader.Load<CameraController>(Resource.Camera);

        if (!SceneLoader.isSceneMenu(scene))
        {
            player = PrefabLoader.Load<PlayerController>(Resource.Player);
            player.transform.position = GetSceneInitialPosition();
        }
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