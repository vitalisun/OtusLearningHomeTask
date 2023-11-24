using Assets.Scripts.GameManager;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameManager gameManager = (GameManager)target;

        if (GUILayout.Button("OnStart"))
        {
            gameManager.OnStart();
        }

        if (GUILayout.Button("Finish"))
        {
            gameManager.Finish();
        }

        if (GUILayout.Button("Pause"))
        {
            gameManager.Pause();
        }

        if (GUILayout.Button("Resume"))
        {
            gameManager.Resume();
        }
    }
}
