using UnityEngine;
using System.ComponentModel;

public enum Resource
{
    Camera,

    [Description("CyborgRat")]
    Player,

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
        GameObject resource = (GameObject)Instantiate(Resources.Load("Prefabs/" + r.Description()));
        T typeResource = RemoveCloneFromName(resource).GetComponent<T>();
        return typeResource;
    }
}
