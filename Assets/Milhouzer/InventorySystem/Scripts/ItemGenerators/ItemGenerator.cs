using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milhouzer.InventorySystem
{
    public interface IItemGenerator
    {
        ItemGenerationStates GenerationStates { get; }

        void Generate();
    }
}
