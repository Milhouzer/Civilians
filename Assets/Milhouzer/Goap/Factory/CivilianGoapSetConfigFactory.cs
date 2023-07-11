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
        builder.AddGoToBuildingGoal<Shop>();
        builder.AddEnterBuildingGoal<Shop>();

        // Actions
        builder.AddWanderAction();
        builder.AddGoToBuildingAction<Shop>();
        builder.AddEnterBuildingAction<Shop>();
        
        // TargetSensors
        builder.AddWanderTargetSensor();
        builder.AddClosestBuildingSensor<Shop>();
        builder.AddClosestBuildingInteriorSensor<Shop>();
        
        // WorldSensors
        builder.AddIsInFrontOfBuildingSensor();
        builder.AddIsInBuildingSensor();

        return builder.Build();
    }
}
