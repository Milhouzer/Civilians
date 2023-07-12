using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Resolver;

public static class CivilianActionsExtension
{
    public static void AddGoToBuildingAction<T>(this GoapSetBuilder builder)
        where T : Building
    {
        builder.AddAction<GoToBuildingAction<T>>()
            .SetTarget<GoToBuildingTarget<T>>()
            .AddEffect<IsAtBuildingEntrance<T>>(true);
    }  
    public static void AddEnterBuildingAction<T>(this GoapSetBuilder builder)
        where T : Building
    {
        builder.AddAction<EnterBuildingAction<T>>()
            .SetTarget<EnterBuildingTarget<T>>()
            .AddCondition<IsAtBuildingEntrance<T>>(Comparison.GreaterThanOrEqual, 1)
            .AddEffect<IsInBuilding<T>>(true)
            .AddEffect<IsAtBuildingEntrance<T>>(false);
    }    
}
