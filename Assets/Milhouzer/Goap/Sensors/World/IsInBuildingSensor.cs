using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;


public class IsInBuildingSensor<T> : LocalWorldSensorBase
    where T : Building
{
    public override void Created()
    {
    }

    public override void Update()
    {
    }

    public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
    {
        var civilian = references.GetCachedComponent<Civilian>();
        
        if (civilian == null)
            return false;

        Debug.Log(civilian.IsInArea<T>(BuildingEnums.AreaType.Inside));
        return civilian.IsInArea<T>(BuildingEnums.AreaType.Inside);
    }
}

