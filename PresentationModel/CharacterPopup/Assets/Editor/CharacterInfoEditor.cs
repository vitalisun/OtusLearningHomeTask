using Lessons.Architecture.PM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using CharacterInfoModel = Lessons.Architecture.PM.CharacterInfoModel;

[CustomEditor(typeof(CharacterInfoModel))]
public class CharacterInfoEditor : Editor
{
    // Temporary fields for demo purposes
    private string statNameToAdd = "";
    private string statNameToRemove = "";

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CharacterInfoModel characterInfo = (CharacterInfoModel)target;

        // Adding a stat (simplified for demo)
        GUILayout.Label("Add Stat");
        statNameToAdd = EditorGUILayout.TextField("Stat Name", statNameToAdd);
        if (GUILayout.Button("Add Stat"))
        {
            // Here you would create a new CharacterStat instance based on the name
            // For demo purposes, assuming a simple constructor
            CharacterStatModel newStat = new CharacterStatModel(statNameToAdd);
            characterInfo.AddStat(newStat);
        }

        // Removing a stat (simplified for demo)
        GUILayout.Label("Remove Stat");
        statNameToRemove = EditorGUILayout.TextField("Stat Name", statNameToRemove);
        if (GUILayout.Button("Remove Stat"))
        {
            // Here you would find the CharacterStat instance based on the name
            // For demo purposes, assuming a simple find method
            try
            {
                CharacterStatModel statToRemove = characterInfo.GetStat(statNameToRemove);
                characterInfo.RemoveStat(statToRemove);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        // Optionally, list all stats (for debugging or inspection)
        GUILayout.Label("All Stats");
        foreach (var stat in characterInfo.GetStats())
        {
            EditorGUILayout.LabelField(stat.Name);
        }
    }
}
