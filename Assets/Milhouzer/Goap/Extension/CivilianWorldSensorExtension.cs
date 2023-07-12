using CrashKonijn.Goap.Classes.Builders;

public static class CivilianWorldSensorExtension
{
    public static void AddIsInFrontOfBuildingSensor<T>(this GoapSetBuilder builder)
        where T : Building
    {
        builder.AddWorldSensor<IsInFrontOfBuildingSensor<T>>()
            .SetKey<IsAtBuildingEntrance<T>>();
    }

    public static void AddIsInBuildingSensor<T>(this GoapSetBuilder builder)
        where T : Building
    {
        builder.AddWorldSensor<IsInBuildingSensor<T>>()
            .SetKey<IsInBuilding<T>>();
    }
}
