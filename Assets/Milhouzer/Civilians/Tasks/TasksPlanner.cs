using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CrashKonijn.Goap.Behaviours;

public class TasksPlanner : MonoBehaviour
{
    private List<TaskBase> tasks = new List<TaskBase>();
    
    private void Awake() {
        TimeCycle.OnTick += OnTimeChanged;    
    }

    public void AddTask<TGoal>() where TGoal : GoalBase
    {
        tasks.Add(new Task<TGoal>());
        Debug.Log(tasks.Count);
    }

    private void OnTimeChanged(DateTime time)
    {
        TaskBase matchingTask = tasks.FirstOrDefault(task => task.executeTime == time);

        if (matchingTask != null)
        {
            StartTask(matchingTask);
        }
    }

    private void StartTask(TaskBase task)
    {

    }

    private class TaskBase 
    { 
        public DateTime executeTime;
    }

    private class Task<T> : TaskBase where T : GoalBase
    {
        
    }
}
