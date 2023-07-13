using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;

using Milhouzer.InventorySystem;

public static class AgentBehaviourExtension
{
    public static void SetItemGoal<TGoal>(this AgentBehaviour agent, Item item, bool endAction)
        where TGoal : ItemGoalBase
    {
        TGoal itemGoal = agent.GoapSet.ResolveGoal<TGoal>();
        itemGoal.item = item;
        agent.SetGoal(itemGoal, endAction);
    }
}
