using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Milhouzer.Interfaces;

public class Civilian : MonoBehaviour, IInteractable
{
    private bool isInteracting;
    public bool IsInteracting { get => isInteracting; }

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

    public void Interact()
    {
        isInteracting = true;
    }

    public void StopInteract()
    {

    }
}
