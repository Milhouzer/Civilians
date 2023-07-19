using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milhouzer.InventorySystem
{
    [CreateAssetMenu(fileName = "Item", menuName = "Inventory System/Item", order = 0)]
    public class Item : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        
        public bool IsCraftable;
        public List<CraftIngredient> Ingredients = new();
        public float CraftingDuration = 1f;
        public bool IsSellable;
        public int Price;
    }
}
