using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using UnityEngine;

using Milhouzer.InventorySystem;

public class CraftItemAction : ActionBase<CraftItemAction.Data>
{
    bool crafted;

    public override void Created()
    {
    }

    public override void Start(IMonoAgent agent, Data data)
    {
        AgentBehaviour agentBehaviour = agent.GetComponent<AgentBehaviour>();
        Inventory inventory = agentBehaviour.GetComponent<Inventory>();
        if(inventory != null && agentBehaviour.CurrentGoal is ItemGoalBase itemGoal)
        {
            data.item = itemGoal.item;
            data.inventory = inventory;
        }
    }

    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        if(!crafted)
        {
            data.inventory.Craft(data.item);
            crafted = true;
        }

        while(data.inventory.IsCrafting)
        {
            return ActionRunState.Continue;
        }
        return ActionRunState.Stop;
    }

    public override void End(IMonoAgent agent, Data data)
    {
    }

    public class Data : IItemActionData
    {
        public ITarget Target { get; set; }
        public Item item { get; set; }
        public Inventory inventory { get; set; }
    }
}

