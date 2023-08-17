using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CrashKonijn.Goap.Behaviours;

namespace Milhouzer.Civilian.Tasks
{
    public interface ITaskCreator<T> where T : GoalBase
    {
        public string TaskName { get; set; }
        public ITaskPlanner taskPlanner { get; }
        public void Open(ITaskPlanner planner);
        public TaskData GetTaskData();
        public void ValidateAndCreateTask();
        public bool ValidateTask();
    }
}
