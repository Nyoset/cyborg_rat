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
    static string GetCustomDescription(object objEnum)
    {
        var fi = objEnum.GetType().GetField(objEnum.ToString());
        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return (attributes.Length > 0) ? attributes[0].Description : objEnum.ToString();
    }

    public static string Description(Resource value)
    {
        return GetCustomDescription(value);
    }

    static GameObject RemoveCloneFromName(GameObject clonedObject)
    {
        clonedObject.name = clonedObject.name.Replace("(Clone)", "");
        return clonedObject;
    }

    public static T Load<T>(Resource r)
    {
        GameObject resource = (GameObject)Instantiate(Resources.Load("Prefabs/" + Description(r)));
        T typeResource = RemoveCloneFromName(resource).GetComponent<T>();
        return typeResource;
    }
}
