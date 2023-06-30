using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ReputationEditor : EditorWindow 
{
    private ReputationConfig selectedConfig;

    private string[] configNames;
    private int selectedIndex;

    [MenuItem("ReputationSystem/Reputation")]
    private static void ShowWindow() {
        var window = GetWindow<ReputationEditor>();
        window.titleContent = new GUIContent("Reputation");
        window.Show();
    }

    private void OnEnable()
    {
        // Find all ScriptableObjects of the specified type
        string[] guids = AssetDatabase.FindAssets("t:ReputationConfig");
        configNames = new string[guids.Length];

        for (int i = 0; i < guids.Length; i++)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
            ReputationConfig config = AssetDatabase.LoadAssetAtPath<ReputationConfig>(assetPath);
            configNames[i] = config.name;
        }
    }

    private void OnGUI() {
        selectedIndex = EditorGUILayout.Popup("Select Config", selectedIndex, configNames);
        selectedConfig = AssetDatabase.LoadAssetAtPath<ReputationConfig>(AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("t:ReputationConfig")[selectedIndex]));
        if (selectedConfig != null)
        {
            DrawScriptableObjectInspector(selectedConfig);
        }

        // Rest of your GUI code...
    }

    private void DrawScriptableObjectInspector(Object scriptableObject)
    {
        EditorGUI.BeginChangeCheck();
        var serializedObject = new SerializedObject(scriptableObject);
        serializedObject.Update();
        Editor editor = Editor.CreateEditor(serializedObject.targetObject);
        editor.OnInspectorGUI();
        serializedObject.ApplyModifiedProperties();
        EditorGUI.EndChangeCheck();
    }
}
