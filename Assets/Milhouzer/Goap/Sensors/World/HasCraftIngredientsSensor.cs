using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Behaviours;

using System.Collections.Generic;
using Milhouzer.InventorySystem;

public class HasCraftIngredientsSensor : LocalWorldSensorBase
{
    public override void Created()
    {
    }

    public override void Update()
    {
    }

    public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
    {
        Inventory inventory = references.GetCachedComponent<Inventory>();

        AgentBehaviour agentBehaviour = references.GetCachedComponent<AgentBehaviour>();
        
        if (inventory == null || agentBehaviour == null)
            return false;

        if(agentBehaviour.CurrentGoal is ItemGoalBase itemGoal)
        {
            List<CraftIngredient> ingredients = itemGoal.item.Ingredients;
            foreach(CraftIngredient ingredient in ingredients)
            {
                if(!inventory.HasItem(ingredient.Name))
                {
                    return false;
                }
            }

            return true;
        }
        
        return false;
    }
}

