using System;
using System.Collections.Generic;
using UnityEngine;

public static class LevelManagerFactory 
{
    static Dictionary<string, Type> map = new Dictionary<string, Type>
    {
        { "Level1", typeof(Level1Manager) }
    };

    public static LevelManager GetLevelManager(string sceneName)
    {
        GameObject levelManager = new GameObject { name = "LevelManager" };
        return levelManager.AddComponent(map[sceneName]) as LevelManager;
    }
}
