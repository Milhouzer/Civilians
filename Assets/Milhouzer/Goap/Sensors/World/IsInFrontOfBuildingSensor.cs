using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;


public class IsInFrontOfBuildingSensor : LocalWorldSensorBase
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
        Debug.Log(civilian + " prout");
        if (civilian == null)
            return false;
        Debug.Log(civilian + " " + civilian.areas.Count);
        return civilian.areas.Count > 0;
    }
}
