using Lessons.Architecture.PM;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(PlayerLevel))]
public class PlayerLevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PlayerLevel playerLevel = (PlayerLevel)target;

        // Read-only fields
        EditorGUILayout.LabelField("Current Level", playerLevel.CurrentLevel.ToString());
        EditorGUILayout.LabelField("Current Experience", playerLevel.CurrentExperience.ToString());
        EditorGUILayout.LabelField("Required Experience", playerLevel.RequiredExperience.ToString());

        // AddExperience button
        if (GUILayout.Button("Add Experience"))
        {
            // Call method with example value, or create a way to input it in the editor
            playerLevel.AddExperience(10); // Example value
        }

        // LevelUp button
        if (GUILayout.Button("Level Up"))
        {
            playerLevel.LevelUp();
        }
    }
}
