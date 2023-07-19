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
        Debug.Log("Buildings " + shops.Count);  
    }

    public override void Update()
    {

    }

    public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
    { 
        AgentBehaviour agentBehaviour = references.GetCachedComponent<AgentBehaviour>();
        
        if (agentBehaviour == null)
            return false;

        if(agentBehaviour.CurrentGoal is ItemGoalBase itemGoal)
        {
            foreach(Shop shop in shops)
            {
                if(shop.Category == itemGoal.item.Category)
                    return true;
            }
        }
        
        return false;
    }
}

