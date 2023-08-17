using CrashKonijn.Goap.Classes.Builders;

public static class CivilianTargetSensorExtension
{
    public static void AddBuyItemPositionSensor(this GoapSetBuilder builder)
    {
        builder.AddTargetSensor<FindShopSellingItem>()
            .SetTarget<BuyItemTarget>();
    }

    public static void AddCollectItemLocationSensor(this GoapSetBuilder builder)
    {
        // builder.AddTargetSensor<CollectItemLocationSensor>()
        //     .SetTarget<CollectItemTarget>();
    }
}
