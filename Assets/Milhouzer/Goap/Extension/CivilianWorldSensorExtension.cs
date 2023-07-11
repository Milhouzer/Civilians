using CrashKonijn.Goap.Classes.Builders;

public static class CivilianWorldSensorExtension
{
    public static void AddIsInFrontOfBuildingSensor(this GoapSetBuilder builder)
    {
        builder.AddWorldSensor<IsInFrontOfBuildingSensor>()
            .SetKey<IsAtBuildingEntrance>();
    }

    public static void AddIsInBuildingSensor(this GoapSetBuilder builder)
    {
        builder.AddWorldSensor<IsInBuildingSensor>()
            .SetKey<IsInBuilding>();
    }
}
