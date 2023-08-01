using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TimeCycle))]
public class TimeCycleEditor : Editor {

    SerializedProperty realTimeTickDuration;
    SerializedProperty tickAmount;

    protected virtual void OnEnable() 
    {
        realTimeTickDuration = serializedObject.FindProperty("realTimeTickDuration");
        tickAmount = serializedObject.FindProperty("tickAmount");
    }
    public override void OnInspectorGUI() {
        EditorGUILayout.PropertyField(realTimeTickDuration, new GUIContent("Tick Duration (Realtime Seconds)"));
        EditorGUILayout.PropertyField(tickAmount, new GUIContent("Tick Amount (In Game Minutes)"));

        DrawRealTimeDayDuration();

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawRealTimeDayDuration()
    {
        float hourDuration = 60f / tickAmount.floatValue * realTimeTickDuration.floatValue;
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white; 
        EditorGUILayout.LabelField("Day duration : " + Mathf.Floor(hourDuration * 24f/60f).ToString() + "mn" + ((hourDuration * 24f/60f - Mathf.Floor(hourDuration * 24f/60f)) * 60f).ToString() + "s", style);
    }
}
