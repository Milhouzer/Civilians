using CrashKonijn.Goap.Classes.Builders;

public static class CivilianTargetSensorExtension
{
    public static void AddBuildingSensor<T>(this GoapSetBuilder builder)
        where T : Building
    {
        builder.AddTargetSensor<ClosestBuildingSensor<T>>()
            .SetTarget<GoToBuildingTarget<T>>();
    }

    public static void AddBuildingInteriorSensor<T>(this GoapSetBuilder builder)
        where T : Building
    {
        builder.AddTargetSensor<ClosestBuildingInteriorSensor<T>>()
            .SetTarget<EnterBuildingTarget<T>>();
    }
    

    public static void AddFindShopSellingItemSensor(this GoapSetBuilder builder)
    {
        builder.AddTargetSensor<FindShopSellingItem>()
            .SetTarget<BuyItemTarget>();
    }
}
