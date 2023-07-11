using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Resolver;
using Demos.Complex.Goals;
using Demos.Complex.Interfaces;
using Demos.Complex.WorldKeys;
using Demos.Shared.Goals;

public static class CivilianGoalsExtension
{
    public static void AddGoToBuildingGoal<T>(this GoapSetBuilder builder)
        where T : Building
    {
        builder.AddGoal<GoToBuildingGoal<T>>()
            .AddCondition<IsAtBuildingEntrance>(Comparison.GreaterThanOrEqual, 1);
    }

    public static void AddEnterBuildingGoal<T>(this GoapSetBuilder builder)
        where T : Building
    {
        builder.AddGoal<EnterBuildingGoal<T>>()
            .AddCondition<IsInBuilding>(Comparison.GreaterThanOrEqual, 1);
    }
}
