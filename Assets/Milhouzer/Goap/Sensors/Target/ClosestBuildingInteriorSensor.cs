using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Classes;

public class ClosestBuildingInteriorSensor<T> : LocalTargetSensorBase
    where T : Building
{    
    private List<T> buildings;

    public override void Created()
    {

    }

    public override void Update()
    {

    }

    public override ITarget Sense(IMonoAgent agent, IComponentReference references)
    {
        
        Civilian civilian = references.GetCachedComponent<Civilian>();

        this.buildings = BuildingManager.GetBuildings<T>();
        
        if (civilian == null)
            return null;

        if(civilian.areas.Count == 0)
            return null;

        Building closest = civilian.areas[0].building;

        return new TransformTarget(closest.Doorstep);
    }
}

