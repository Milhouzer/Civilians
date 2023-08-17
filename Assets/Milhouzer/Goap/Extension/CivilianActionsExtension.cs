using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Resolver;

public static class CivilianActionsExtension
{    
    public static void AddCraftItemAction(this GoapSetBuilder builder)
    {
        builder.AddAction<CraftItemAction>()
            .SetTarget<CraftItemTarget>()
            .AddCondition<HasCraftIngredients>(Comparison.GreaterThanOrEqual, 1)
            .AddEffect<HasItems>(true);
    }

    public static void AddBuyItemAction(this GoapSetBuilder builder)
    {
        builder.AddAction<BuyItemAction>()
            .SetTarget<BuyItemTarget>()
            .AddCondition<CanBuyItem>(Comparison.GreaterThanOrEqual, 1)
            .AddEffect<HasItems>(true);
    }

    public static void AddCollectItemAction(this GoapSetBuilder builder)
    {
        // builder.AddAction<CollectItemAction>()
        //     .SetTarget<CollectItemTarget>()
        //     .AddCondition<CanCollectItem>(Comparison.GreaterThanOrEqual, 1)
        //     .AddEffect<HasItems>(true);
    }
}
