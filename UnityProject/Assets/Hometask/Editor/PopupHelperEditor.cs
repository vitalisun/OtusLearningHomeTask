using Assets.Homeworks.PresentationModel.Scripts;
using Lessons.Architecture.PM;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterPopupHelper))]
public class PopupHelperEditor : Editor
{
    private string statName = "";
    private int valueToChange = 0;


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Отображает стандартные поля

        CharacterPopupHelper popupHelper = (CharacterPopupHelper)target;

        // Добавить пользовательский интерфейс в инспектор
        if (GUILayout.Button("Show Popup"))
        {
            popupHelper.ShowPopup();
        }

        if (GUILayout.Button("Add Experience"))
        {
            var randomRange = Random.Range(10, 70);

            popupHelper.AddExperience(randomRange);
        }

        // Adding a stat (simplified for demo)
        GUILayout.Label("Add Stat");
        statName = EditorGUILayout.TextField("Stat SelectedFighterName", statName);

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Add Stat"))
        {
            // Here you would create a new CharacterStat instance based on the name
            // For demo purposes, assuming a simple constructor
            popupHelper.AddStat(statName);
        }
        if (GUILayout.Button("Remove Stat"))
        {
            // Here you would create a new CharacterStat instance based on the name
            // For demo purposes, assuming a simple constructor
            popupHelper.RemoveStat(statName);
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Add all stats"))
        {
            popupHelper.AddDefaultStats();
        }

        if (GUILayout.Button("Remove all stats"))
        {
            popupHelper.ClearAllStats();
            
        }

        if (GUILayout.Button("Get all stats"))
        {
            popupHelper.GetAllStats();
        }

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();

        valueToChange = EditorGUILayout.IntField(valueToChange);

        if (GUILayout.Button("Change"))
        {
            popupHelper.ChangeStatValue(statName, valueToChange);
        }

        GUILayout.EndHorizontal();
    }
}