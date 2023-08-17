using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Milhouzer.Utility;
using TMPro;

namespace Milhouzer.InventorySystem
{
    public class ItemSelector : MonoBehaviour, IValueSelector<Item>
    {
        [SerializeField]
        private Item defaultValue;
        public Item DefaultValue { get => defaultValue; }

        private Item value;
        public Item Value { get => value; }

        public event ValueChangedDelegate OnValueChanged;

        [SerializeField]
        private TMP_Dropdown itemDropdown;

        public void AddValueChangedListener(ValueChangedDelegate listener)
        {
            OnValueChanged += listener;
        }

        public void RemoveValueChangedListener(ValueChangedDelegate listener)
        {
            OnValueChanged -= listener;
        }

        public void SetValue(Item newValue)
        {
            value = newValue;
            OnValueChanged?.Invoke();
        }

        private void Awake() 
        {
            SetSelectableItems();
        }

        private void Start()
        {
            SetValue(defaultValue);
        }
        
        private void SetSelectableItems()
        {
            List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

            foreach(Item item in InventoryManager.Instance.GetItems())
            {
                options.Add(new TMP_Dropdown.OptionData(item.Name));
            }
            
            itemDropdown.AddOptions(options);
        }

        public void OnSelectionChange(int selectedIndex) 
        {
            Item item = InventoryManager.Instance.CreateItem(itemDropdown.options[selectedIndex].text);
            if(item != null)
            {
                SetValue(item);
            }
        }
    }
}
