using UnityEngine;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Configs.Interfaces;

using Milhouzer.InventorySystem;

public class CivilianGoapSetConfigFactory : GoapSetFactoryBase
{
    public override IGoapSetConfig Create()
    {
        var builder = new GoapSetBuilder("Civilian");
        
        // Debugger
        // builder.SetAgentDebugger<AgentDebugger>();

    #region Goals

        // builder.AddCraftItemGoal();
        builder.AddGetItemGoal();


    #endregion

    #region Actions
        builder.AddCraftItemAction();
        builder.AddBuyItemAction();
        builder.AddCollectItemAction();

    #endregion
        
    #region Target Sensors

        builder.AddBuyItemPositionSensor();
        builder.AddCollectItemLocationSensor();

    #endregion
        
    #region World Sensors
        builder.AddHasCraftIngredientsSensor();
        builder.AddHasItemsSensor();
        builder.AddIsItemAvailableInShop();

    #endregion

        return builder.Build();
    }
}
