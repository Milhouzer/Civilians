using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

using System.Reflection;

using CrashKonijn.Goap.Behaviours;

using Milhouzer.InventorySystem;

public class TasksPlannerView : Singleton<TasksPlannerView>
{
    public Dropdown tasksDropdown;
    public Dropdown itemsDropdown;

    [SerializeField]
    TasksPlanner currentPlanner;
    [SerializeField]
    List<Item> items;

    private List<Type> goalTypes = new List<Type>();
    private List<string> goalTypesNames = new List<string>();

    private void Awake()
    {
        ScanForGoalTypes();
    }

    private void ScanForGoalTypes()
    {
        goalTypes.Clear();

        // Get the assembly where your scripts are located
        Assembly executingAssembly = Assembly.GetExecutingAssembly();

        // Loop through the types in the assembly to find types that inherit from GoalBase
        Type[] types = executingAssembly.GetTypes();
        foreach (Type type in types)
        {
            if (type.IsSubclassOf(typeof(GoalBase)))
            {
                goalTypes.Add(type);
                goalTypesNames.Add(type.ToString());
            }
        }

        // Print the found goal types to the console (optional)
        PrintGoalTypes();
    }

    private void PrintGoalTypes()
    {
        tasksDropdown.AddOptions(goalTypesNames);

        itemsDropdown.AddOptions(items.Select(x => x.Name).ToList());
    }

    void Show(TasksPlanner planner)
    {
        
    }

    public void OnSelectedTaskChanged()
    {

    }

    public void OnValidateTask()
    {
        Type goalTypeToAdd = goalTypes[tasksDropdown.value];
        MethodInfo addTaskMethod = typeof(TasksPlanner).GetMethod("AddTask").MakeGenericMethod(goalTypeToAdd);
        addTaskMethod.Invoke(currentPlanner, null);
    }

}
