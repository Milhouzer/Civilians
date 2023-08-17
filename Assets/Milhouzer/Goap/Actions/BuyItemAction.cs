using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using UnityEngine;

using Milhouzer.InventorySystem;

public class BuyItemAction : ActionBase<BuyItemAction.Data>
{
    public override void Created()
    {
    }

    public override void Start(IMonoAgent agent, Data data)
    {
        Inventory inventory = agent.GetComponent<Inventory>();
        if(inventory != null)
        {
            data.inventory = inventory;
        }
    }

    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        data.RemainingDistance = Vector3.Distance(agent.transform.position, data.Target.Position);
        
        if (data.RemainingDistance > 0.5f)
            return ActionRunState.Continue;

        object target;
        agent.CurrentGoalData.Target.GetTarget(out target);
        if(target is Item targetItem)
        {
            data.inventory.Add(targetItem);
        }

        return ActionRunState.Stop;
    }

    public override void End(IMonoAgent agent, Data data)
    {
    }

    public class Data : IActionData
    {
        public ITarget Target { get; set; }
        public float RemainingDistance { get; set; }
        public Inventory inventory { get; set; }
    }
}

