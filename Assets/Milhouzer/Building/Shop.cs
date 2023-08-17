using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Milhouzer.InventorySystem;

[RequireComponent(typeof(Inventory))]
public class Shop : Building
{
    public Inventory inventory;
    public ItemCategory Category;
}
