using UnityEngine;
using UnityEngine.SceneManagement;
using System.ComponentModel;

public enum GameScene
{
    [Description("MainMenu")]
    MainMenu,
    [Description("Level")]
    Level,
}

public class SceneLoader
{
    public static int AmountOfLevels()
    {
        return SceneManager.sceneCountInBuildSettings;
    }

    public static void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public static void LoadScene(GameScene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public static void LoadLevel(int levelIndex)
    {
        string sceneName = GameScene.Level.ToString() + levelIndex;
        SceneManager.LoadScene(sceneName);
    }

    public static void StartGame()
    {
        LoadLevel(1);
    }

    public static bool isSceneMenu(Scene scene)
    {
        if (scene.name == GameScene.MainMenu.ToString())
        {
            return true;
        }
        return false;
    }
}
