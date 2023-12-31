using UnityEngine;
using System;
using System.Reflection;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;

using Milhouzer.Civilian.Tasks;

namespace Milhouzer.Civilian
{
    public class CivilianBrain : MonoBehaviour, ITaskRunner
    {
        private AgentBehaviour agent;
        private IGoapRunner goapRunner;

        private ITaskPlanner taskPlanner;

        bool lookingForGoal = true;

        private void Awake()
        {
            this.agent = this.GetComponent<AgentBehaviour>();
            this.goapRunner = FindObjectOfType<GoapRunnerBehaviour>();
            this.taskPlanner = GetComponent<ITaskPlanner>();
            agent.GoapSet = this.goapRunner.GetGoapSet("Civilian");
        }

        private void OnEnable()
        {
            this.agent.Events.OnActionStop += this.OnActionStop;
            this.agent.Events.OnNoActionFound += this.OnNoActionFound;
            this.agent.Events.OnGoalCompleted += this.OnGoalCompleted;

            this.taskPlanner.OnTaskCompleted += this.DetermineTask;
        }

        private void OnDisable()
        {
            this.agent.Events.OnActionStop -= this.OnActionStop;
            this.agent.Events.OnNoActionFound -= this.OnNoActionFound;
            this.agent.Events.OnGoalCompleted -= this.OnGoalCompleted;

            this.taskPlanner.OnTaskCompleted -= this.DetermineTask;
        }

        private void Start()
        {

        }
        
        private void OnNoActionFound(IGoalBase goal)
        {

        }

        private void OnGoalCompleted(IGoalBase goal)
        {
            taskPlanner.OnGoalCompleted(goal);
        }

        private void OnActionStop(IActionBase action)
        {
            // this.GetNextTask();
        }

        private void DetermineTask()
        {

        }

        private void GetNextTask()
        {
            TaskBase task = taskPlanner.CurrentTask;
            if(task == null)
                return;


            Type taskGenericType = task.GetGenericTypeDefinition();

            // Task is valid
            if(taskGenericType != typeof(TaskBase))
            {
                MethodInfo setGoalMethod = typeof(CivilianBrain).GetMethod("SetGoal", BindingFlags.NonPublic | BindingFlags.Instance);
                MethodInfo setGoalTyped = setGoalMethod.MakeGenericMethod(taskGenericType);
                IGoalTarget target = task.Data.target;
                
                setGoalTyped.Invoke(this, new object[] { false , target });
            }
        }

        private void SetGoal<T>(bool endAction, IGoalTarget target) where T : GoalBase
        {
            agent.SetGoal<T>(endAction, target);
            lookingForGoal = false;
        }
    }
}
