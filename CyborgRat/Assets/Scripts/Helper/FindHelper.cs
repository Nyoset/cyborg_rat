using UnityEngine;

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
}
