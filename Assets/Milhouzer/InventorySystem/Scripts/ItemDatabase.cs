using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections.ObjectModel;

namespace Milhouzer.InventorySystem
{
    [CreateAssetMenu(fileName = "Item Database", menuName = "Inventory System/Item Database")]
    public class ItemDatabase : ScriptableObject, IEnumerable<Item>
    {
        [SerializeField]
        private List<Item> items = new List<Item>();

        public Item GetItemByName(string name)
        {
            return items.Find(x => x.Name == name);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}