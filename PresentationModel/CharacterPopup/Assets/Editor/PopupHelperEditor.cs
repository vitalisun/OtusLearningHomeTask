using Assets.Homeworks.PresentationModel.Scripts;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CharacterPopupHelper))]
public class PopupHelperEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); // Отображает стандартные поля

        CharacterPopupHelper popupHelper = (CharacterPopupHelper)target;

        // Добавить пользовательский интерфейс в инспектор
        if (GUILayout.Button("Show Popup"))
        {
            popupHelper.ShowPopup();
        }
    }
}