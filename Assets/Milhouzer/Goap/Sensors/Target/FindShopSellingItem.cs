using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Behaviours;

using Milhouzer.InventorySystem;

public class FindShopSellingItem : LocalTargetSensorBase
{

    List<Shop> buildings = new();
    List<Inventory> inventories = new();

    public override void Created()
    {
        this.buildings = BuildingManager.GetBuildings<Shop>();    
        PopulateInventories();
    }

    private void PopulateInventories()
    {
        inventories = buildings
            .Select(building => building.GetComponent<Inventory>())
            .Where(inventory => inventory != null)
            .ToList();
    }

    public override void Update()
    {

    }

    public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    {
        AgentBehaviour agentBehaviour = references.GetCachedComponent<AgentBehaviour>();
        
        if (agentBehaviour == null)
            return null;

        if(agentBehaviour.CurrentGoal is ItemGoalBase itemGoal)
        {
            for (int i = 0; i < inventories.Count; i++)
            {
                Inventory inventory = inventories[i];
                if(inventory.HasItem(itemGoal.item))
                {
                    return new TransformTarget(buildings[i].Entrance);
                }
            }
        }

        return null;
    }
}

