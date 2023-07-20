using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CrashKonijn.Goap.Behaviours;

public class TasksPlanner : MonoBehaviour
{
    private List<TaskBase> tasks = new List<TaskBase>();

    public void AddTask<TGoal>() where TGoal : GoalBase
    {
        tasks.Add(new Task<TGoal>());
        Debug.Log(tasks.Count);
    }

    // Base class for the Task<T> classes to be stored in the list
    private class TaskBase { }

    // Task<T> class to hold a specific goal type
    private class Task<T> : TaskBase where T : GoalBase
    {
        // Implement your task logic here
    }
}
