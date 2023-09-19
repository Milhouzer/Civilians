using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Milhouzer.Utility.Interfaces;

namespace Milhouzer.InventorySystem
{
    public class IntSelector : MonoBehaviour, IValueSelector<int>
    {
        
        [SerializeField]
        private int defaultValue;
        public int DefaultValue { get => defaultValue; }
        
        private int value;
        public int Value { get => value; }
        
        public event ValueChangedDelegate OnValueChanged;
        
        [SerializeField]
        private int MinValue;
        [SerializeField]
        private int MaxValue;
        
        [SerializeField]
        private TMP_InputField amount;

        public void AddValueChangedListener(ValueChangedDelegate listener)
        {
            OnValueChanged += listener;
        }

        public void RemoveValueChangedListener(ValueChangedDelegate listener)
        {
            OnValueChanged -= listener;
        }

        public void SetValue(int newValue)
        {
            value = Mathf.Clamp(newValue, MinValue, MaxValue);
            OnValueChanged?.Invoke();
            Repaint();
        }

        void Start()
        {
            SetValue(defaultValue);
        }
        
        public void Decrease()
        {
            SetValue(value - 1);
        }


        public void Increase()
        {
            SetValue(value + 1);
        }

        public void OnInputFieldChanged(string input)
        {
            if (int.TryParse(input, out int inputValue))
            {
                value = inputValue;
                OnValueChanged?.Invoke();
            }
        }

        private void Repaint()
        {
            amount.text = value.ToString();
        }
    }
}
