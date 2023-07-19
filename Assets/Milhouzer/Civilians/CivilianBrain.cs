using UnityEngine;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using Demos.Shared.Goals;

using Milhouzer.InventorySystem;

public class CivilianBrain : MonoBehaviour
{
    private AgentBehaviour agent;
    private IGoapRunner goapRunner;

    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private Item itemToCraft;
    private bool crafted;

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
            if(!crafted)
            {
                SetItemGoal<CraftItemGoal>(itemToCraft);
                crafted = true;
            }
            // this.agent.SetGoal<EnterBuildingGoal<FoodShop>>(false);
        }else
        {
            this.agent.SetGoal<WanderGoal>(false);
        }
    }


    /// <summary>
    /// This must work so it can be extended to any ScriptableObject 
    /// </summary>
    /// <param name="item"></param>
    /// <typeparam name="TGoal"></typeparam>
    protected virtual void SetItemGoal<TGoal>(Item item)
        where TGoal : ItemGoalBase
    {
        agent.SetItemGoal<TGoal>(item, false);
    }
}
