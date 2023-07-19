using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Milhouzer.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        private bool isCrafting;
        public bool IsCrafting { get => isCrafting; }

        [SerializeField]
        protected List<Item> items = new();

        public void Add(Item item)
        {
            items.Add(item);
        }

        public void Remove(Item item)
        {
            items.Remove(GetItem(item));
        }

        public void Remove(string itemName)
        {
            items.Remove(GetItem(itemName));
        }

        public bool HasItem(Item item)
        {
            return items.Find(x => x.Name == item.Name);
        }
        
        public bool HasItem(string itemName)
        {
            return items.Find(x => x.Name == itemName);
        }

        public Item GetItem(Item item)
        {
            return items.FirstOrDefault(x => x.Name == item.Name);
        }

        public Item GetItem(string itemName)
        {
            return items.FirstOrDefault(x => x.Name == itemName);
        }

        private void Awake() {
            for (int i = 0; i < items.Count; i++)
            {
                items[i] = Instantiate(items[i]);
            }
        }

        public bool Craft(Item item)
        {
            StartCoroutine(CraftCoroutine(item));
            return true;
        }

        private IEnumerator CraftCoroutine(Item item)
        {
            isCrafting = true;
            yield return new WaitForSeconds(item.CraftingDuration);
            List<CraftIngredient> ingredients = item.Ingredients;
            foreach(CraftIngredient ingredient in ingredients)
            {
                Remove(ingredient.Name);
            }
            Add(item);
            isCrafting = false;
        }
    }
}
