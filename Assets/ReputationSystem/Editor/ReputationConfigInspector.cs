using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ReputationConfig))]
public class ReputationConfigInspector : Editor 
{
    SerializedProperty index;
    SerializedProperty peoples;
    SerializedProperty peopleReputation;
    SerializedProperty reputations;

    private string[] peoplesNames;
    private int selectedPeople;

    protected virtual void OnEnable()
    {
        index = serializedObject.FindProperty("index");
        peoples = serializedObject.FindProperty("peoples");
        peopleReputation = serializedObject.FindProperty("peopleReputation");

        peoplesNames = new string[peoples.arraySize];
        for (int i = 0; i < peoples.arraySize; i++)
        {
           SerializedProperty people = peoples.GetArrayElementAtIndex(i);
           SerializedProperty nameProperty = people.FindPropertyRelative("PeopleName");
           peoplesNames[i] = nameProperty.stringValue;
        }
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();


        EditorGUILayout.PropertyField(index);

        DrawPeoplesList();
        selectedPeople = EditorGUILayout.Popup("Select People", selectedPeople, peoplesNames);
        UpdatePeopleReputationSize();
        
        EditorGUILayout.PropertyField(peopleReputation);

        serializedObject.ApplyModifiedProperties();
    }
    
    private void DrawPeoplesList()
    {
        EditorGUI.indentLevel++;
        EditorGUILayout.LabelField("Peoples");

        // Draw the size field
        int size = peoples.arraySize;
        size = EditorGUILayout.IntField("Size", size); 
        if (size != peoples.arraySize)
        {
            while (size > peoples.arraySize)
            {
                peoples.InsertArrayElementAtIndex(peoples.arraySize);
            }
            while (size < peoples.arraySize)
            {
                peoples.DeleteArrayElementAtIndex(peoples.arraySize - 1);
            }
        }

        // Draw the elements
        for (int i = 0; i < peoples.arraySize; i++)
        {
            SerializedProperty elementProperty = peoples.GetArrayElementAtIndex(i);
            EditorGUILayout.PropertyField(elementProperty);
        }

        EditorGUI.indentLevel--;
    }

    private void UpdatePeopleReputationSize()
    {
        if (peoples.arraySize != peopleReputation.arraySize)
        {
            peopleReputation.arraySize = peoples.arraySize;
        }
    }
}
