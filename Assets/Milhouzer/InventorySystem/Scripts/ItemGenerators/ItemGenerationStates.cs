using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Milhouzer.InventorySystem
{
    [CreateAssetMenu(fileName = "ItemGenerationStates", menuName = "InventorySystem/ItemGenerationStates", order = 0)]
    public class ItemGenerationStates : ScriptableObject 
    {
        private int statesCount = 1;
        public int Count => statesCount;

        [SerializeField] private List<ItemGenerationState> states = new List<ItemGenerationState>();

        private int currentState = 0;
        public ItemGenerationState CurrentState => states[currentState];
        public bool IsFullyGenerated => currentState == states.Count - 1;
        
        private void OnValidate() 
        {        
            statesCount = states.Count;
        }

        public bool Update()
        {
            if(currentState == states.Count - 1)
            {
                return false;
            }

            currentState++;
            Debug.Log(currentState);
            return true;
        }
    }

    [System.Serializable]
    public struct ItemGenerationState
    {
        public Item item;
        public float duration;
    }
}
