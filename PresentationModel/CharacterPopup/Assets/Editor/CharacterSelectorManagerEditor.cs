using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Homeworks.MVxPractice.Task1.Scripts;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
  

    [CustomEditor(typeof(CharacterSelectorManager))]
    public class CharacterSelectorManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector(); // Draws the default inspector

            // Reference to the target object
            CharacterSelectorManager manager = (CharacterSelectorManager)target;

            // Add buttons for Create and Destroy methods
            if (GUILayout.Button("Create Character Selector"))
            {
                // Call the Create method on the CharacterSelectorManager
                manager.Create();
            }

            if (GUILayout.Button("Destroy Character Selector"))
            {
                // Call the Destroy method on the CharacterSelectorManager
                manager.Destroy();
            }
        }
    }

}
