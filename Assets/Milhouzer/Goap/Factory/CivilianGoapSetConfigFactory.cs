using UnityEngine;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Configs.Interfaces;


using Demos.Shared;
using Demos.Complex.Factories.Extensions;

public class CivilianGoapSetConfigFactory : GoapSetFactoryBase
{
    public override IGoapSetConfig Create()
    {
        var builder = new GoapSetBuilder("Civilian");
        
        // Debugger
        builder.SetAgentDebugger<AgentDebugger>();

        // Goals
        builder.AddWanderGoal();
        
        // builder.AddCleanItemsGoal();
        // builder.AddFixHungerGoal();

        // Actions
        builder.AddWanderAction();

        // builder.AddHaulItemAction();
        // builder.AddPickupItemAction<IEatable>();
        // builder.AddEatAction();
        
        // TargetSensors
        builder.AddWanderTargetSensor();
        // builder.AddTransformTargetSensor();
        // builder.AddClosestItemTargetSensor<IEatable>();
        
        // // WorldSensors
        // builder.AddIsHoldingSensor<IEatable>();
        
        // builder.AddIsInWorldSensor<IEatable>();
        
        // builder.AddItemOnFloorSensor();

        return builder.Build();
    }
}
