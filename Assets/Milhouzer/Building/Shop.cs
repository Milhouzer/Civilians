using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Milhouzer.InventorySystem;

[RequireComponent(typeof(Inventory))]
public class Shop : Building, IPOI<Shop>
{
    private POI<Shop> poi;
    public POI<Shop> Poi => poi;
    public Inventory inventory;
    public ItemCategory Category;
    
    protected override void Awake()
    {
        poi = new POI<Shop>(gameObject);

        base.Awake();
    }
}
