using System.Collections;
using System.Collections.Generic;
using Lessons.Architecture.PM;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(UserInfoModel))]
public class UserInfoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        UserInfoModel userInfo = (UserInfoModel)target;

        // Display the read-only fields
        EditorGUILayout.LabelField("Name", userInfo.Name);
        EditorGUILayout.LabelField("Description", userInfo.Description);
        EditorGUILayout.ObjectField("Icon", userInfo.Icon, typeof(Sprite), allowSceneObjects: false);

        // Fields for changing values
        string newName = EditorGUILayout.TextField("New Name", userInfo.Name);
        string newDescription = EditorGUILayout.TextField("New Description", userInfo.Description);
        Sprite newIcon = (Sprite)EditorGUILayout.ObjectField("New Icon", null, typeof(Sprite), allowSceneObjects: false);

        // Buttons to apply changes
        if (GUILayout.Button("Change Name"))
        {
            userInfo.ChangeName(newName);
        }

        if (GUILayout.Button("Change Description"))
        {
            userInfo.ChangeDescription(newDescription);
        }

        if (GUILayout.Button("Change Icon") && newIcon != null)
        {
            userInfo.ChangeIcon(newIcon);
        }
    }
}