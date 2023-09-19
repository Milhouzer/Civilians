using System;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;

namespace Milhouzer.Civilian.Tasks
{
    public enum TaskExecutionTrigger
    {
        FixedTime,
        ASAP,
        OnFreeTime,
    }

    public enum TaskRunState
    {
        Planned,
        Running,
        Aborted,
        Completed
    }

    public struct TaskData
    {
        public DateTime executionTime;
        public DateTime endTime;
        public TimeSpan duration;
        public string name;

        public IGoalTarget target;

        public TaskData(DateTime executionTime, TimeSpan duration, string name, IGoalTarget target)
        {
            this.executionTime = executionTime;
            this.duration = duration;
            this.endTime = this.executionTime.Add(duration);
            this.name = name;

            this.target = target;
        }
    }

    /// <TODO>
    /// 
    /// - Implement TaskRunState to track the state of a task.
    /// - Notify when a task is finished, aborted, started, etc.
    /// - Remove Finished task from the list so the tasksrunners can start searching for a new task.
    /// - ITasksRunner ?
    /// 
    /// </TODO>
    public class TaskBase 
    { 
        protected TaskData taskData;
        public TaskData Data { get => taskData; }
        
        private TaskExecutionTrigger executionType;
        public TaskExecutionTrigger ExecutionType => executionType;

        private TaskRunState state;
        public TaskRunState State { get => state; }
        
        private Guid guid;
        
        public Guid Guid { get => guid; }

        public TaskBase(TaskData data, TaskExecutionTrigger executionType)
        {
            taskData = data;
            this.executionType = executionType;
            this.guid = Guid.NewGuid();
            this.state = TaskRunState.Planned;
        }

        public void Start()
        {
            this.state = TaskRunState.Running;
        }

        public void Complete()
        {
            this.state = TaskRunState.Completed;
        }

        public void Stop()
        {
            this.state = TaskRunState.Aborted;
        }

        public virtual Type GetGenericTypeDefinition()
        {
            return typeof(TaskBase);
        }
    }

    public class Task<T> : TaskBase where T : IGoalBase
    {
        public Task(TaskData data, TaskExecutionTrigger executionType) : base(data, executionType)
        {

        }

        public override Type GetGenericTypeDefinition()
        {
            return typeof(T);
        }
    }
}