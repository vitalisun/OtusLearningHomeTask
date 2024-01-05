using UnityEngine;
using UnityEditor;
using Assets.Homeworks.MVxPractice.Task3.Scripts;

[CustomEditor(typeof(FightingSelectorManager))]
public class FightingSelectorManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Draws the default inspector

        FightingSelectorManager manager = (FightingSelectorManager)target;

        GUILayout.BeginHorizontal(); // Start a horizontal group

        // Create button
        if (GUILayout.Button("Create"))
        {
            // Record for undo
            Undo.RecordObject(manager, "Create Fighting Selector");

            // Call the Create method
            manager.Create();

            // Since we are instantiating a new object, set dirty to save state
            EditorUtility.SetDirty(manager);
        }

        // Destroy button
        if (GUILayout.Button("Destroy"))
        {
            // Record for undo
            Undo.RecordObject(manager, "Destroy Fighting Selector");

            // Call the Destroy method
            manager.Destroy();

            // Set dirty to save state
            EditorUtility.SetDirty(manager);
        }

        GUILayout.EndHorizontal(); // End the horizontal group
    }
}

