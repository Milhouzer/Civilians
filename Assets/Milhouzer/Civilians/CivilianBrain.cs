using UnityEngine;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using Demos.Shared.Goals;


public class CivilianBrain : MonoBehaviour
{
    private AgentBehaviour agent;
        private IGoapRunner goapRunner;

    private void Awake()
    {
        this.agent = this.GetComponent<AgentBehaviour>();
        this.goapRunner = FindObjectOfType<GoapRunnerBehaviour>();
        agent.GoapSet = this.goapRunner.GetGoapSet("Civilian");
    }

    private void OnEnable()
    {
        this.agent.Events.OnActionStop += this.OnActionStop;
        this.agent.Events.OnNoActionFound += this.OnNoActionFound;
        this.agent.Events.OnGoalCompleted += this.OnGoalCompleted;
    }

    private void OnDisable()
    {
        this.agent.Events.OnActionStop -= this.OnActionStop;
        this.agent.Events.OnNoActionFound -= this.OnNoActionFound;
        this.agent.Events.OnGoalCompleted -= this.OnGoalCompleted;
    }

    private void Start()
    {
        this.agent.SetGoal<WanderGoal>(false);
    }
    
    private void OnNoActionFound(IGoalBase goal)
    {
        this.agent.SetGoal<WanderGoal>(false);
    }

    private void OnGoalCompleted(IGoalBase goal)
    {
        Debug.Log(goal + " completed");
    }

    private void OnActionStop(IActionBase action)
    {
        this.DetermineGoal();
    }

    protected virtual void DetermineGoal()
    {
        if(GoapTester.Instance.GoToFishShop)
        {
            this.agent.SetGoal<EnterBuildingGoal<FishShop>>(false);
        }else if(GoapTester.Instance.GoToFoodShop)
        {
            this.agent.SetGoal<EnterBuildingGoal<FoodShop>>(false);
        }else
        {
            this.agent.SetGoal<WanderGoal>(false);
        }
    }
}
