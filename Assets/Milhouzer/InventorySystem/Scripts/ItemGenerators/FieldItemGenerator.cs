using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Milhouzer.InventorySystem
{
    public class FieldItemGenerator : MonoBehaviour, IItemGenerator
    {
        [SerializeField]
        private List<ItemGenerationLocation> generationLocations;

        [SerializeField]
        private ItemGenerationStates generationStates;
        public ItemGenerationStates GenerationStates { get => generationStates; }


        public virtual void Generate()
        {
            ItemGenerationLocation location = GetEmptyLocation();
            if(location == null)
                return;

            location.Populate(generationStates);
        }

        public ItemGenerationLocation GetEmptyLocation()
        {
            return generationLocations.FirstOrDefault(x => x.IsEmpty);
        }
    }
}
