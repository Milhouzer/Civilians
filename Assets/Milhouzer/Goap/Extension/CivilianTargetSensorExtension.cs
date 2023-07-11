using CrashKonijn.Goap.Classes.Builders;

public static class CivilianTargetSensorExtension
{
    public static void AddClosestBuildingSensor<T>(this GoapSetBuilder builder)
        where T : Building
    {
        builder.AddTargetSensor<ClosestBuildingSensor<T>>()
            .SetTarget<GoToBuildingTarget>();
    }

    public static void AddClosestBuildingInteriorSensor<T>(this GoapSetBuilder builder)
        where T : Building
    {
        builder.AddTargetSensor<ClosestBuildingInteriorSensor<T>>()
            .SetTarget<EnterBuildingTarget>();
    }
}
