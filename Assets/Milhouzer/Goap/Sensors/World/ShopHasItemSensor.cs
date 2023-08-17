using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Behaviours;

using System.Collections.Generic;
using Milhouzer.InventorySystem;

using UnityEngine;

public class ShopHasItemSensor : LocalWorldSensorBase
{
    List<Shop> shops = new();

    public override void Created()
    {
        this.shops = BuildingManager.GetBuildings<Shop>();
    }

    public override void Update()
    {

    }

    public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
    { 
        AgentBehaviour agentBehaviour = references.GetCachedComponent<AgentBehaviour>();
        
        if (agentBehaviour == null)
            return false;

        object target;
        agentBehaviour.CurrentGoalData.Target.GetTarget(out target);

        Debug.Log(agentBehaviour.CurrentGoal + " " + agentBehaviour.CurrentGoalData + " Can buy items : " + target);
        if(target is Item targetItem)
        {
            foreach(Shop shop in shops)
            {
                if(shop.inventory.HasItem(targetItem))
                    return true;
            }
        }
        
        return false;
    }
}

