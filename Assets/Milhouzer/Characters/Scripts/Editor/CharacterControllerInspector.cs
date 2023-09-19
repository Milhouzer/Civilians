using UnityEngine;
using UnityEditor;

namespace Milhouzer.Character
{
    [CustomEditor(typeof(CharacterController))]
    public class CharacterControllerInspector : Editor {

        private CharacterController characterController;

        private void OnEnable() 
        {
            characterController = (CharacterController)target;
        }

        public override void OnInspectorGUI() 
        {
            EditorGUILayout.LabelField("Current State :", characterController.CurrentState == null ? "None" : (characterController.CurrentState.Tag + " " + characterController.CurrentState.Timer));

            DrawDefaultInspector();
        }
    }
}
