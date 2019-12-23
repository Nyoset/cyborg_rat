using UnityEngine;
using System.ComponentModel;

public enum Resource
{
    [Description("Camera")]
    Camera,

    [Description("Player")]
    Player,

    [Description("MenuButton")]
    MenuButton,
}

public class PrefabLoader : MonoBehaviour
{
    static GameObject RemoveCloneFromName(GameObject clonedObject)
    {
        clonedObject.name = clonedObject.name.Replace("(Clone)", "");
        return clonedObject;
    }

    public static T Load<T>(Resource r)
    {
        GameObject resource = (GameObject)Instantiate(Resources.Load("Prefabs/" + r.ToString()));
        T typeResource = RemoveCloneFromName(resource).GetComponent<T>();
        return typeResource;
    }
}
