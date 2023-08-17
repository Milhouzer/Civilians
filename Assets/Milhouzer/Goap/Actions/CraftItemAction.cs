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
        Inventory inventory = agent.GetComponent<Inventory>();
        if(inventory != null)
        {
            data.inventory = inventory;
        }
    }

    public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
    {
        // if(!crafted)
        // {
        //     data.inventory.Craft(data.item);
        //     crafted = true;
        // }

        // while(data.inventory.IsCrafting)
        // {
        //     return ActionRunState.Continue;
        // }
        return ActionRunState.Stop;
    }

    public override void End(IMonoAgent agent, Data data)
    {
    }

    public class Data : IActionData
    {
        public ITarget Target { get; set; }
        public Inventory inventory { get; set; }
    }
}

