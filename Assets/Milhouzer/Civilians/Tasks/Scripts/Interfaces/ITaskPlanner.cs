using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CrashKonijn.Goap.Behaviours;

namespace Milhouzer.Civilian.Tasks
{
    public interface ITaskPlanner
    {
        TaskBase CurrentTask { get; }
        List<TaskBase> Tasks { get; }

        public void AddTask<T>(TaskData data, TaskExecutionTrigger taskExecutionTime) where T : GoalBase;
        public void StartTask(TaskBase task);
        public void EndTask();
    }
}

