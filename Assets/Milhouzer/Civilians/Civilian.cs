using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : MonoBehaviour
{
    private Building targetBuilding;
    public Building TargetBuilding
    {
        get { return targetBuilding; }
        set { targetBuilding = value; }
    }

    public List<BuildingArea> areas = new List<BuildingArea>();

    public void EnterArea(BuildingArea area)
    {
        areas.Add(area);
    }

    public void ExitArea(BuildingArea area)
    {
        areas.Remove(area);
    }


}
