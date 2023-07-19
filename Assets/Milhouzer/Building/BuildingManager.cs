using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class BuildingManager
{
    static List<Building> buildings = new List<Building>();
    public static List<Building> Buildings { get => buildings; }

    
    public static void RegisterBuilding(Building building)
    {
        buildings.Add(building);
        Debug.Log("Register " + building);
    }

    public static List<T> GetBuildings<T>()
    {
        return buildings.OfType<T>().ToList();
    }
}
