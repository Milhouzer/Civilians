using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ReputationEditor : EditorWindow 
{
    private ReputationConfig selectedConfig;
    Editor editor;
    SerializedObject selectedConfigObject;

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
        ReputationConfig lastSelectedConfig = AssetDatabase.LoadAssetAtPath<ReputationConfig>(AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("t:ReputationConfig")[selectedIndex]));
        if (lastSelectedConfig != selectedConfig)
        {
            OnSelectedConfigChanged(lastSelectedConfig);
        }
        
        if(editor != null)
            editor.OnInspectorGUI();

        // Rest of your GUI code...
    }

    private void OnSelectedConfigChanged(ReputationConfig newSelectedConfig)
    {
        selectedConfig = newSelectedConfig;
        DrawScriptableObjectInspector(selectedConfig);
    }

    private void DrawScriptableObjectInspector(Object config)
    {
        EditorGUI.BeginChangeCheck();

        selectedConfigObject = new SerializedObject(config);
        selectedConfigObject.Update();

        editor = Editor.CreateEditor(selectedConfigObject.targetObject);
        
        EditorGUILayout.BeginVertical(GUI.skin.box);
        editor.OnInspectorGUI();
        EditorGUILayout.EndVertical();

        selectedConfigObject.ApplyModifiedProperties();
        
        EditorGUI.EndChangeCheck();
    }
}
