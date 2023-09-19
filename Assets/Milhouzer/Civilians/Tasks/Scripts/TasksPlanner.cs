using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using Milhouzer.DayNightCycle;

namespace Milhouzer.Civilian.Tasks
{
    public class TasksPlanner : MonoBehaviour, ITaskPlanner
    {
        private TaskBase currentTask;
        public TaskBase CurrentTask 
        { 
            get 
            {
                if(currentTask == null)
                {
                    return tasks.FirstOrDefault(task => task.ExecutionType == TaskExecutionTrigger.ASAP);
                }

                return currentTask;
            }
        }

        private List<TaskBase> tasks = new List<TaskBase>();
        public List<TaskBase> Tasks { get => tasks; }
        
        public delegate void AddTaskDelegate(TaskData data);
        public static event AddTaskDelegate OnTaskAdded;

        event ITaskPlanner.TaskCompleted ITaskPlanner.OnTaskCompleted
        {
            add
            {
                // throw new NotImplementedException();
            }

            remove
            {
                // throw new NotImplementedException();
            }
        }

        private void Awake() 
        {
            TimeCycle.OnTick += OnTimeChanged;    
        }

        private void OnTimeChanged(DateTime time)
        {
            TaskBase matchingTask = tasks.FirstOrDefault(task => (task.ExecutionType == TaskExecutionTrigger.FixedTime && task.Data.executionTime == time));

            if (matchingTask != null)
            {
                StartTask(matchingTask);
            }
        }

        public void AddTask<TGoal>(TaskData data, TaskExecutionTrigger taskExecutionTIme) where TGoal : GoalBase
        {
            var task = new Task<TGoal>(data, taskExecutionTIme);
            tasks.Add(task);
            
            OnTaskAdded?.Invoke(data);
        }

        public void OnGoalCompleted(IGoalBase goal)
        {
            EndTask();
        }

        public void StartTask(TaskBase task)
        {
            currentTask = task;
            currentTask.Start();
        }

        public void EndTask()
        {
            currentTask.Complete();
            currentTask = null;
        }

        void ITaskPlanner.GoalStart(IGoalBase goal)
        {
            throw new NotImplementedException();
        }
    }
}