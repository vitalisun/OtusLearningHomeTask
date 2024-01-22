using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{

    [CustomEditor(typeof(PopupManager))]
    public class PopupManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI(); // Draw the default inspector

            // Cast the target to PopupManager
            PopupManager popupManager = (PopupManager)target;

            GUILayout.BeginHorizontal();

            // Show Popup button
            if (GUILayout.Button("Create Popup"))
            {
                popupManager.CreatePopup();
            }

            if (GUILayout.Button("Destroy Popup"))
            {
                popupManager.DestroyPopup();
            }

            GUILayout.EndHorizontal();
        }
    }

}
