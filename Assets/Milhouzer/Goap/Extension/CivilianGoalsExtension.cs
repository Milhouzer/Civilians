using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Resolver;

using Milhouzer.InventorySystem;

public static class CivilianGoalsExtension
{
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
