using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public enum Tag
{
    Colorable
}

public static class FindHelper
{
    public static T FindComponentInChildWithTag<T>(this GameObject parent, Tag tag) where T : Component
    {
        Transform t = parent.transform;
        foreach (Transform tr in t)
        {
            if (tr.tag == tag.ToString())
            {
                return tr.GetComponent<T>();
            }
        }
        return null;
    }


    public static List<T> FindType<T>()
    {
        List<T> interfaces = new List<T>();
        GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (var rootGameObject in rootGameObjects)
        {
            T[] childrenInterfaces = rootGameObject.GetComponentsInChildren<T>();
            foreach (var childInterface in childrenInterfaces)
            {
                interfaces.Add(childInterface);
            }
        }
        return interfaces;
    }
}
