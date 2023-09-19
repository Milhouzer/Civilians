using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Milhouzer.Utility.Interfaces;

namespace Milhouzer.InventorySystem
{
    public class ItemAmountUI : MonoBehaviour
    {
        [SerializeField]
        private IValueSelector<int> amountSelector;
        [SerializeField]
        private IValueSelector<Item> itemSelector;

        private ItemAmount itemAmount;
        public ItemAmount Amount { get => itemAmount; }

        private void Awake() {
            itemAmount = new ItemAmount(null, 0);

            /// <TODO>
            /// Make Interface serializable using a wrapper.
            /// </TODO>
            amountSelector = GetComponentInChildren<IValueSelector<int>>();
            itemSelector = GetComponentInChildren<IValueSelector<Item>>();
        }

        private void OnEnable() 
        {
            itemSelector.AddValueChangedListener(Validate);
            amountSelector.AddValueChangedListener(Validate);
        }

        private void OnDisable()
        {
            itemSelector.RemoveValueChangedListener(Validate);
            amountSelector.RemoveValueChangedListener(Validate);
        }

        public void Validate()
        {
            itemAmount.item = itemSelector.Value;
            itemAmount.amount = amountSelector.Value;
        }
    }
}
