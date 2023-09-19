using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Milhouzer.Civilian.Tasks;
using CrashKonijn.Goap.Behaviours;

/// <TODO>
/// Calendar should not inherit from Singleton.
/// </TODO>
using Milhouzer.Utility;
public class Calendar : Singleton<Calendar>
{
    [SerializeField]
    private float ContentHeight = 1200f;
    public float HourSubdivision { get => ContentHeight/24f; }

    [SerializeField]
    private Day[] days;
    [SerializeField]
    private GameObject taskUI;

    protected override void Awake() 
    {
        days = GetComponentsInChildren<Day>();
        TasksPlanner.OnTaskAdded += OnTaskAdded;
    }

    public void OnTaskAdded(TaskData data)
    {
        // Check if visible, a task UI should only be added to the UI if it's visible.
        
        float height = (data.executionTime.Hour + data.executionTime.Minute / 60f) * HourSubdivision;
        GameObject go = Instantiate(this.taskUI, Vector3.zero, Quaternion.identity);
        RectTransform rt = go.GetComponent<RectTransform>();
        go.transform.SetParent(days[0].transform, false);
        rt.anchoredPosition = new Vector2(0, -height);

        var taskUI = go.GetComponent<TaskUI>();
        taskUI.SetTask(data);
    }
}
