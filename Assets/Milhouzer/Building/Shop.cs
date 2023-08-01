using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Milhouzer.InventorySystem;

[RequireComponent(typeof(ShopInventory))]
public class Shop : Building
{
    public ItemCategory Category;
}
