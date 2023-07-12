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

          builder.AddWanderGoal();

          builder.AddGoToBuildingGoalEntrance<FoodShop>();
          builder.AddGoToBuildingGoalEntrance<FishShop>();
          
          builder.AddEnterBuildingGoal<FoodShop>();
          builder.AddEnterBuildingGoal<FishShop>();

          // builder.AddCraftItemGoal<Item>();

    #endregion

    #region Actions

          builder.AddWanderAction();

          builder.AddGoToBuildingAction<FoodShop>();
          builder.AddGoToBuildingAction<FishShop>();

          builder.AddEnterBuildingAction<FoodShop>();
          builder.AddEnterBuildingAction<FishShop>();
          
    #endregion
        
    #region Target Sensors

            builder.AddWanderTargetSensor();

            builder.AddBuildingSensor<FoodShop>();
            builder.AddBuildingSensor<FishShop>();

            builder.AddBuildingInteriorSensor<FoodShop>();
            builder.AddBuildingInteriorSensor<FishShop>();

            // builder.AddShopSensor<>();

    #endregion
        
    #region World Sensors

        builder.AddIsInFrontOfBuildingSensor<FoodShop>();
        builder.AddIsInFrontOfBuildingSensor<FishShop>();
        
        builder.AddIsInBuildingSensor<FoodShop>();
        builder.AddIsInBuildingSensor<FishShop>();

    #endregion

        return builder.Build();
    }
}
