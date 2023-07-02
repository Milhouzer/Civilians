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
    SerializedProperty impactScores;
    SerializedProperty reputations;

    private string[] peoplesNames;
    private int selectedPeople;

    private int[] relationsValue;

    protected virtual void OnEnable()
    {
        peoples = serializedObject.FindProperty("peoples");
        peopleReputation = serializedObject.FindProperty("peopleReputation");
        impactScores = serializedObject.FindProperty("impactScores");

        peoplesNames = new string[peoples.arraySize];
        relationsValue = new int[peopleReputation.arraySize];
        
        UpdatePeopleNames();
    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        EditorGUILayout.PropertyField(impactScores);
        DrawPeoplesList();
        UpdatePeopleNames();
        int newSelectedPeople = EditorGUILayout.Popup("Select People", selectedPeople, peoplesNames);
        if(newSelectedPeople != selectedPeople)
        {
            OnSelectedPeopleChanged(newSelectedPeople);
        }
        
        UpdatePeopleReputationSize();
        if (GUILayout.Button("UpdateSizes"))
        {
            UpdateRelationsSize();
        }
        DrawSelectedPeopleRelations();
        serializedObject.ApplyModifiedProperties();
    }
    
    private void OnSelectedPeopleChanged(int newValue)
    {
        selectedPeople = newValue;
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

            SerializedObject assetObject = new SerializedObject(elementProperty.objectReferenceValue);
            SerializedProperty nameProperty = assetObject.FindProperty("peopleName");

            peoplesNames[i] = nameProperty.stringValue;
        }

        EditorGUI.indentLevel--;
    }

    private void DrawSelectedPeopleRelations()
    {
        
        EditorGUI.indentLevel++;

        // EditorGUILayout.PropertyField(peopleReputation);
        SerializedProperty selectedPeopleRelations = peopleReputation.GetArrayElementAtIndex(selectedPeople);
        SerializedProperty relations = selectedPeopleRelations.FindPropertyRelative("reputations");
        if(relations != null)
        {
            EditorGUILayout.LabelField(peoplesNames[selectedPeople] + " relations");
            for (int i = 0; i < relations.arraySize; i++)
            {
                SerializedProperty relationValue = relations.GetArrayElementAtIndex(i);
                if(relationValue != null)
                    relationValue.intValue = EditorGUILayout.IntSlider("Relation with " + peoplesNames[i], relationValue.intValue, -100, 100);
            }
        }

        EditorGUI.indentLevel--;
    }

    private void UpdatePeopleNames()
    {
        // for (int i = 0; i < peoples.arraySize; i++)
        // {
        //     SerializedProperty people = peoples.GetArrayElementAtIndex(i);
        //     if(nameProperty != null )
        //         peoplesNames[i] = nameProperty.stringValue;
        //     else
        //         peoplesNames[i] = i.ToString();
        // }
    }
    
    private void UpdatePeopleReputationSize()
    {
        if (peoples.arraySize != peopleReputation.arraySize)
        {
            peopleReputation.arraySize = peoples.arraySize;
        }
    }

    private void UpdateRelationsSize()
    {
        for (int i = 0; i < peopleReputation.arraySize; i++)
        {
            SerializedProperty reputations = peopleReputation.GetArrayElementAtIndex(i);
            SerializedProperty relations = reputations.FindPropertyRelative("reputations");
            if(relations != null && relations.arraySize != peopleReputation.arraySize)
            {
                relations.arraySize = peopleReputation.arraySize;
            }
            Debug.Log(i + " : " + relations.arraySize);
        }
    }
}
