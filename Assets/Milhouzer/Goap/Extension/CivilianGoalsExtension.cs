using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Resolver;
using Demos.Complex.Goals;
using Demos.Complex.Interfaces;
using Demos.Complex.WorldKeys;
using Demos.Shared.Goals;

using Milhouzer.InventorySystem;

public static class CivilianGoalsExtension
{
    public static void AddGoToBuildingGoalEntrance<T>(this GoapSetBuilder builder)
        where T : Building
    {
        builder.AddGoal<GoToBuildingGoal<T>>()
            .AddCondition<IsAtBuildingEntrance<T>>(Comparison.GreaterThanOrEqual, 1);
    }

    public static void AddEnterBuildingGoal<T>(this GoapSetBuilder builder)
        where T : Building
    {
        builder.AddGoal<EnterBuildingGoal<T>>()
            .AddCondition<IsInBuilding<T>>(Comparison.GreaterThanOrEqual, 1);
    }

    public static void AddCraftItemGoal(this GoapSetBuilder builder)
    {
        builder.AddGoal<CraftItemGoal>()
            .AddCondition<HasCraftedItems>(Comparison.GreaterThanOrEqual, 1);
    }

    public static void AddGetItemGoal(this GoapSetBuilder builder)
    {
        builder.AddGoal<GetItemGoal>()
            .AddCondition<HasItems>(Comparison.GreaterThanOrEqual, 1);
    }
}
