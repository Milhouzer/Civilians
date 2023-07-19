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


    public static void AddHasCraftIngredientsSensor(this GoapSetBuilder builder)
    {
        builder.AddWorldSensor<HasCraftIngredientsSensor>()
            .SetKey<HasCraftIngredients>();
    }

    public static void AddHasItemsSensor(this GoapSetBuilder builder)
    {
        builder.AddWorldSensor<HasItemsSensor>()
            .SetKey<HasItems>();
    }

    public static void AddIsItemAvailableInShop(this GoapSetBuilder builder)
    {
        builder.AddWorldSensor<ShopHasItemSensor>()
            .SetKey<CanBuyItem>();
    }

}
