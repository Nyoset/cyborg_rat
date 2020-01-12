using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameMaster 
{
    const string initialPositionTag = "InitialPosition";
    const string menuTag = "Menu";

    public InputHandler inputHandler;

    public static GameMaster instance = null;
    public GameObject masterObject;

    public CameraController mainCamera;
    public PlayerController player;
    public LevelManager currentLevelManager;

    GameData gameData;

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
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        mainCamera = PrefabLoader.Load<CameraController>(Resource.Camera);

        if (!SceneLoader.isSceneMenu(scene))
        {
            player = PrefabLoader.Load<PlayerController>(Resource.Player);
            player.transform.position = GetSceneInitialPosition();

            currentLevelManager = LevelManagerFactory.GetLevelManager(scene.name);
        }
    }

    public Type GetSceneManagerClass()
    {
        string className = typeof(LevelManager).ToString().Replace(GameScene.Level.Description(), SceneLoader.GetSceneName());
        return Type.GetType(className);
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

    public void StartGame(string playerName)
    {
        gameData = new GameData(playerName);
        SceneLoader.StartGame();
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(gameData);
    }

    public void LoadGame(string playerName)
    {
        gameData = SaveSystem.LoadGame(playerName);
    }
}