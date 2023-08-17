using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Milhouzer.Utility;

namespace Milhouzer.InventorySystem
{
    /// <summary>
    /// Acts as the interface between external components and the database
    /// </summary>
    public class InventoryManager : Singleton<InventoryManager>
    {
        [SerializeField]
        private ItemDatabase items;

        public Item CreateItem(string itemName)
        {
            Item item = items.GetItemByName(itemName);
            if(item != null)
            {
                return Instantiate(item);
            }

            return null;
        }
        
        public IEnumerable<Item> GetItems()
        {
            return items;
        }
    }
}
