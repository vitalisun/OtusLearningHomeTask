using Lessons.Architecture.PM;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(CharacterStatModel))]
public class CharacterStatEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //CharacterStatModel characterStat = (CharacterStatModel)target;

        //// Display the read-only fields
        //EditorGUILayout.LabelField("Name", characterStat.Name);
        //EditorGUILayout.LabelField("Value", characterStat.Value.ToString());

        //// Field to enter the new value
        //int newValue = EditorGUILayout.IntField("New Value", characterStat.Value);

        //// Button to change the value
        //if (GUILayout.Button("Change Value"))
        //{
        //    characterStat.ChangeValue(newValue);
        //}
    }
}