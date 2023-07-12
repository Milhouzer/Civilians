using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : MonoBehaviour
{
    // private Building targetBuilding;
    // public Building TargetBuilding
    // {
    //     get { return targetBuilding; }
    //     set { targetBuilding = value; }
    // }

    Dictionary<BuildingEnums.AreaType, List<Building>> visitedAreas = new();

    private void Awake() 
    {
        foreach (BuildingEnums.AreaType area in (BuildingEnums.AreaType[]) BuildingEnums.AreaType.GetValues(typeof(BuildingEnums.AreaType)))
        {
            visitedAreas.Add(area, new List<Building>());
        }
    }

    public void EnterArea(BuildingEnums.AreaType area, Building building)
    {
        visitedAreas[area].Add(building);
    }

    public void ExitArea(BuildingEnums.AreaType area, Building building)
    {
        visitedAreas[area].Remove(building);
    }

    public bool IsInArea<T>(BuildingEnums.AreaType area)
        where T : Building
    {
        int count = 0;
        foreach(Building building in visitedAreas[area])
        {
            if(building is T TBuilding)
                count++;
        }
        return count > 0;
    }


}
