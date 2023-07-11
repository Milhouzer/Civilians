using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Resolver;

public static class CivilianActionsExtension
{
    public static void AddGoToBuildingAction<T>(this GoapSetBuilder builder)
        where T : Building
    {
        builder.AddAction<GoToBuildingAction<T>>()
            .SetTarget<GoToBuildingTarget>()
            .AddEffect<IsAtBuildingEntrance>(true);
    }  
    public static void AddEnterBuildingAction<T>(this GoapSetBuilder builder)
        where T : Building
    {
        builder.AddAction<EnterBuildingAction<T>>()
            .SetTarget<EnterBuildingTarget>()
            .AddCondition<IsAtBuildingEntrance>(Comparison.GreaterThanOrEqual, 1)
            .AddEffect<IsAtBuildingEntrance>(false)
            .AddEffect<IsInBuilding>(true);
    }    
}
