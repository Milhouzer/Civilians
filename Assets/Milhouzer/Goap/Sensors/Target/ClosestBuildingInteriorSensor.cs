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
        this.buildings = BuildingManager.GetBuildings<T>();
        
        Building closest = GetClosestBuilding(this.buildings, agent.transform.position);

        if (closest == null)
            return null;

        return new TransformTarget(closest.Doorstep);
    }

    private T GetClosestBuilding(List<T> buildings, Vector3 position)
    {
        return buildings
            .OrderBy(x => Vector3.Distance(x.transform.position, position))
            .FirstOrDefault();
    }
}

