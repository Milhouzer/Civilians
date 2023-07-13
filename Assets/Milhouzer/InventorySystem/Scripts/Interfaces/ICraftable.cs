using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milhouzer.InventorySystem
{
    public interface ICraftable
    {
        List<CraftIngredient> Ingredients { get; }
        public void Craft();
    }
}
