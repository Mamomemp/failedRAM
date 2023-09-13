//https://www.youtube.com/watch?v=H8j4CbnVTfQ Litan Roy
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class HierarchyItemColor
{
    static HierarchyItemColor()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HierarcheWindowItemOnGUI;
    }

    static void HierarcheWindowItemOnGUI(int instanceID, Rect selectRect)
    {

        var gameobject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (gameobject != null && gameobject.name.StartsWith("/black ", System.StringComparison.Ordinal)) //Black
        {
            EditorGUI.DrawRect(selectRect, Color.black);
            EditorGUI.DropShadowLabel(selectRect, gameobject.name.Replace("/black ", "").ToUpperInvariant());

        } else if (gameobject != null && gameobject.name.StartsWith("/r ", System.StringComparison.Ordinal)) //Red
        {
            EditorGUI.DrawRect(selectRect, Color.red);
            EditorGUI.DropShadowLabel(selectRect, gameobject.name.Replace("/r ", "").ToUpperInvariant());

        } else if (gameobject != null && gameobject.name.StartsWith("/g ", System.StringComparison.Ordinal)) //Green
        {
            EditorGUI.DrawRect(selectRect, Color.green);
            EditorGUI.DropShadowLabel(selectRect, gameobject.name.Replace("/g ", "").ToUpperInvariant());

        } else if (gameobject != null && gameobject.name.StartsWith("/y ", System.StringComparison.Ordinal)) //Yellow
        {
            EditorGUI.DrawRect(selectRect, Color.yellow);
            EditorGUI.DropShadowLabel(selectRect, gameobject.name.Replace("/y ", "").ToUpperInvariant());

        } else if (gameobject != null && gameobject.name.StartsWith("/m ", System.StringComparison.Ordinal)) //Magenta
        {
            EditorGUI.DrawRect(selectRect, Color.magenta);
            EditorGUI.DropShadowLabel(selectRect, gameobject.name.Replace("/m ", "").ToUpperInvariant());

        } else if (gameobject != null && gameobject.name.StartsWith("/b ", System.StringComparison.Ordinal)) //Blue
        {
            EditorGUI.DrawRect(selectRect, Color.blue);
            EditorGUI.DropShadowLabel(selectRect, gameobject.name.Replace("/b ", "").ToUpperInvariant());

        } else if (gameobject != null && gameobject.name.StartsWith("/grey ", System.StringComparison.Ordinal)) //Grey
        {
            EditorGUI.DrawRect(selectRect, Color.grey);
            EditorGUI.DropShadowLabel(selectRect, gameobject.name.Replace("/grey ", "").ToUpperInvariant());

        } else if (gameobject != null && gameobject.name.StartsWith("/c ", System.StringComparison.Ordinal)) //Cyan
        {
            EditorGUI.DrawRect(selectRect, Color.cyan);
            EditorGUI.DropShadowLabel(selectRect, gameobject.name.Replace("/c ", "").ToUpperInvariant());

        }
        else if (gameobject != null && gameobject.name.StartsWith("/w ", System.StringComparison.Ordinal)) //white
        {
            EditorGUI.DrawRect(selectRect, Color.white);
            EditorGUI.DropShadowLabel(selectRect, gameobject.name.Replace("/w ", "").ToUpperInvariant());

        }

    }
}