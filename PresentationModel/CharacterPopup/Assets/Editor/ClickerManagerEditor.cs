using UnityEngine;
using UnityEditor;
using Assets.Homeworks.MVxPractice.Task2.Scripts;

[CustomEditor(typeof(ClickerManager))]
public class ClickerManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Draws the default inspector

        ClickerManager clickerManager = (ClickerManager)target;

        GUILayout.BeginHorizontal(); // Start a horizontal layout for buttons

        // Create button
        if (GUILayout.Button("Create"))
        {
            clickerManager.Create();
        }

        // Destroy button
        if (GUILayout.Button("Destroy"))
        {
            clickerManager.Destroy();
        }

        GUILayout.EndHorizontal(); // End the horizontal layout
    }
}

