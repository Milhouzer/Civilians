using System;
using System.Linq;
using CrashKonijn.Goap.Configs.Interfaces;
using CrashKonijn.Goap.Interfaces;

using Milhouzer.InventorySystem;

namespace CrashKonijn.Goap.Behaviours
{
    public abstract class ItemGoalBase : GoalBase
    {
        public Item item;
    }
}