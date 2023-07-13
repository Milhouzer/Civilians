using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Milhouzer.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        protected List<Item> items = new();

        public virtual Item[] Get()
        {
            return items.ToArray();
        }

        protected virtual void Awake() 
        {
            InitializeItems();
        }

        private void InitializeItems()
        {
            // items.Add(new ApplePie(def));
            for (int i = 0; i < items.Count; i++)
            {
                // items[i] = Instantiate(items[i]);
            }
        }
    }
}
