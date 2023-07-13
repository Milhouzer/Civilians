using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milhouzer.InventorySystem
{
    public interface ISellable
    {
        int Price { get; }
        public void Sell();
    }
}
