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
        this.agent.SetGoal<WanderGoal>(false);
    }

    private void OnActionStop(IActionBase action)
    {
        // this.UpdateHunger();
        
        // if (this.agent.CurrentGoal is FixHungerGoal)
        //     return;
        
        this.DetermineGoal();
    }

    private void UpdateHunger()
    {
        // if (this.hunger.hunger > 80)
        // {
        //     this.agent.SetGoal<FixHungerGoal>(false);
        //     return;
        // }

        // if (this.agent.CurrentGoal is not FixHungerGoal)
        //     return;
        
        // if (this.hunger.hunger < 20)
        //     this.DetermineGoal();
    }

    private void DetermineGoal()
    {
        this.agent.SetGoal<WanderGoal>(false);
        // switch (this.agentType)
        // {
        //     case AgentType.Miner:
        //         this.DetermineMinerGoals();
        //         break;
        //     case AgentType.WoodCutter:
        //         this.DetermineWoodCutterGoals();
        //         break;
        //     case AgentType.Smith:
        //         this.DetermineSmithGoals();
        //         break;
        //     case AgentType.Cleaner:
        //         this.DetermineCleanerGoals();
        //         break;
        // }
    }

    private void DetermineMinerGoals()
    {
        // if (this.inventory.Count<Pickaxe>() == 0 && this.itemCollection.Get<Pickaxe>().Length >= 1)
        // {
        //     this.agent.SetGoal<PickupItemGoal<Pickaxe>>(false);
        //     return;
        // }
        
        // if (this.itemCollection.Get<Iron>().Length <= 2)
        // {
        //     this.agent.SetGoal<GatherItemGoal<Iron>>(false);
        //     return;
        // }
        
        // this.agent.SetGoal<WanderGoal>(false);
    }
    
    private void DetermineWoodCutterGoals()
    {
        // if (this.inventory.Count<Axe>() == 0 && this.itemCollection.Get<Axe>().Length >= 1)
        // {
        //     this.agent.SetGoal<PickupItemGoal<Axe>>(false);
        //     return;
        // }
        
        // if (this.itemCollection.Get<Wood>().Length <= 2)
        // {
        //     this.agent.SetGoal<GatherItemGoal<Wood>>(false);
        //     return;
        // }
        
        // this.agent.SetGoal<WanderGoal>(false);
    }
    
    private void DetermineSmithGoals()
    {
        // if (this.itemCollection.Get<Axe>().Length <= 1)
        // {
        //     this.agent.SetGoal<CreateItemGoal<Axe>>(false);
        //     return;
        // }
        
        // if (this.itemCollection.Get<Pickaxe>().Length <= 1)
        // {
        //     this.agent.SetGoal<CreateItemGoal<Pickaxe>>(false);
        //     return;
        // }

        // this.agent.SetGoal<WanderGoal>(false);
    }
    
    private void DetermineCleanerGoals()
    {
        // if (this.itemCollection.Count(false, false) > 0)
        // {
        //     this.agent.SetGoal<CleanItemsGoal>(false);
        //     return;
        // }
        
        // this.agent.SetGoal<WanderGoal>(false);
    }
}