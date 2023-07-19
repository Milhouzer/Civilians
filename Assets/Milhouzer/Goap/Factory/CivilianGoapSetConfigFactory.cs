using UnityEngine;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Configs.Interfaces;

using Demos.Shared;
using Demos.Complex.Factories.Extensions;

using Milhouzer.InventorySystem;

public class CivilianGoapSetConfigFactory : GoapSetFactoryBase
{
    public override IGoapSetConfig Create()
    {
        var builder = new GoapSetBuilder("Civilian");
        
        // Debugger
        builder.SetAgentDebugger<AgentDebugger>();

    #region Goals

        // builder.AddCraftItemGoal();
        builder.AddGetItemGoal();
        builder.AddWanderGoal();

        // builder.AddGoToBuildingGoalEntrance<FoodShop>();
        // builder.AddGoToBuildingGoalEntrance<FishShop>();
        
        // builder.AddEnterBuildingGoal<FoodShop>();
        // builder.AddEnterBuildingGoal<FishShop>();


    #endregion

    #region Actions
        builder.AddCraftItemAction();
        builder.AddBuyItemAction();
        // builder.AddHarvestItemAction();

        builder.AddWanderAction();

        // builder.AddGoToBuildingAction<FoodShop>();
        // builder.AddGoToBuildingAction<FishShop>();

        // builder.AddEnterBuildingAction<FoodShop>();
        // builder.AddEnterBuildingAction<FishShop>();
        
    #endregion
        
    #region Target Sensors

        builder.AddWanderTargetSensor();
        builder.AddFindShopSellingItemSensor();

        // builder.AddBuildingSensor<FoodShop>();
        // builder.AddBuildingSensor<FishShop>();

        // builder.AddBuildingInteriorSensor<FoodShop>();
        // builder.AddBuildingInteriorSensor<FishShop>();

    #endregion
        
    #region World Sensors
        builder.AddHasCraftIngredientsSensor();
        builder.AddHasItemsSensor();
        builder.AddIsItemAvailableInShop();

        // builder.AddIsInFrontOfBuildingSensor<FoodShop>();
        // builder.AddIsInFrontOfBuildingSensor<FishShop>();
        
        // builder.AddIsInBuildingSensor<FoodShop>();
        // builder.AddIsInBuildingSensor<FishShop>();

    #endregion

        return builder.Build();
    }
}
