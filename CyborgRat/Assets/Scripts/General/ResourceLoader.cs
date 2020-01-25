using UnityEngine;
using System.ComponentModel;
using System.IO;

public enum Resource
{
    [Description("General/Camera")]
    Camera,

    [Description("General/CyborgRat")]
    Player,

    [Description("UI/CyborgRat")]
    MenuButton,
}

public enum SpriteFile
{
    [Description("Tiles/Doors/g3895")]
    PerpendicularDoor,
    [Description("Tiles/Doors/g3894")]
    ParallelDoor,
}

public class ResourceLoader : MonoBehaviour
{
    static GameObject RemoveCloneFromName(GameObject clonedObject)
    {
        clonedObject.name = clonedObject.name.Replace("(Clone)", "");
        return clonedObject;
    }

    public static T Load<T>(Resource r)
    {
        GameObject resource = "Prefabs".File(r).Load();
        T typeResource = RemoveCloneFromName(resource).GetComponent<T>();
        return typeResource;
    }

    public static Sprite Load(SpriteFile s)
    {
        return Resources.Load<Sprite>("Graphics".File(s));
    }
}

public static class FolderPath
{
    public static string CD(this string str)
    {
        return str + Path.DirectorySeparatorChar;
    }

    public static string File(this string str, string file)
    {
        return str.CD() + file;
    }

    public static string File(this string str, Resource file)
    {
        return str.File(file.Description());
    }

    public static string File(this string str, SpriteFile file)
    {
        return str.File(file.Description());
    }

    public static GameObject Load(this string str)
    {
        return (GameObject)GameObject.Instantiate(Resources.Load(str));
    }
}
