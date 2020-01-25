using System;
using UnityEngine;
using UnityEditor;

public static class NullHelper
{
    public static EditorApplication.CallbackFunction CallbackEditor(this MonoBehaviour g, Action f)
    {
        return () => { if (g != null) f(); };
    }
}
