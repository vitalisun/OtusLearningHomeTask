using Lessons.Architecture.PM;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(PlayerLevelModel))]
public class PlayerLevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PlayerLevelModel playerLevelModel = (PlayerLevelModel)target;

        // Read-only fields
        EditorGUILayout.LabelField("Current Level", playerLevelModel.CurrentLevel.ToString());
        EditorGUILayout.LabelField("Current Experience", playerLevelModel.CurrentExperience.ToString());
        EditorGUILayout.LabelField("Required Experience", playerLevelModel.RequiredExperience.ToString());

        // AddExperience button
        if (GUILayout.Button("Add Experience"))
        {
            // Call method with example value, or create a way to input it in the editor
            playerLevelModel.AddExperience(10); // Example value
        }

        // LevelUp button
        if (GUILayout.Button("Level Up"))
        {
            playerLevelModel.LevelUp();
        }
    }
}
