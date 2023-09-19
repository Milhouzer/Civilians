using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

using Milhouzer.Civilian.Tasks;

namespace Milhouzer.Civilian
{
    public class ShoppingList : MonoBehaviour/*, ITaskCreator<GetItemGoal>*/
    {
    //     private ITaskPlanner _taskPlanner;
    //     public ITaskPlanner taskPlanner => _taskPlanner;

    //     [SerializeField]
    //     private string taskName;
    //     public string TaskName
    //     {
    //         get { return taskName; }
    //         set { taskName = value; }
    //     }

    //     [SerializeField]
    //     private TextMeshProUGUI label;
    //     [SerializeField]
    //     private Transform itemsAmountContainer;
    //     [SerializeField]
    //     private GameObject itemAmountPrefab;

    //     private List<ItemAmountUI> uiList = new();

    //     [SerializeField]
    //     GameObject taskPlannerDebug;

    //     private void Awake() 
    //     {
    //         _taskPlanner = taskPlannerDebug.GetComponent<ITaskPlanner>();
    //     }

    //     public void AddItemAmount()
    //     {
    //         GameObject go = Instantiate(itemAmountPrefab, itemsAmountContainer);
    //         ItemAmountUI itemAmount = go.GetComponent<ItemAmountUI>();
    //         uiList.Add(itemAmount);

    //         go.SetActive(true);
    //     }

    //     public void RemoveItemAmount(ItemAmountUI ui)
    //     {
    //         uiList.Remove(ui);
    //         Destroy(ui.gameObject);
    //     }

    //     public void Open(ITaskPlanner planner)
    //     {
    //         _taskPlanner = planner;
    //     }

    //     public TaskData GetTaskData()
    //     {
    //         DateTime executionTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 4, 0, 0);
    //         TimeSpan taskDuration = new TimeSpan(1,0,0);
    //         TaskData data = new TaskData(executionTime, taskDuration, "Shopping List", uiList[0].Amount);
            
    //         return data;
    //     }

    //     public bool ValidateTask()
    //     {
    //         return true;
    //     }

    //     public void ValidateAndCreateTask()
    //     {
    //         if(ValidateTask())
    //         {   
    //             int count = uiList.Count;
    //             for (int i = 0; i < count; i++)
    //             {
    //                 TaskData data = GetTaskData();
    //                 _taskPlanner.AddTask<GetItemGoal>(data, TaskExecutionTrigger.ASAP);
    //                 RemoveItemAmount(uiList[0]);
    //             }
    //         }
    //     }
    }
}
