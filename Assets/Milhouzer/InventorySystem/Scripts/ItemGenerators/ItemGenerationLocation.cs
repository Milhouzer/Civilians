using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Milhouzer.InventorySystem
{
    public class ItemGenerationLocation : MonoBehaviour
    {
        private bool isEmpty = true;
        public bool IsEmpty => isEmpty;

        private ItemGenerationStates states;

        private GameObject stateObject;

        private float currentTick;

        private void Update() 
        {
            if(Tick())
            {
                UpdateState();
            }
        }

        public void Populate(ItemGenerationStates states)
        {
            isEmpty = false;
            this.states = Instantiate(states);
            UpdateState();
        }

        private bool Tick()
        {
            if(isEmpty || states.IsFullyGenerated)
                return false;


            currentTick += Time.deltaTime;
            if(currentTick >= states.CurrentState.duration)
            {
                if(this.states.Update())
                {
                    currentTick = 0;
                    return true;
                }
            }

            return false;
        }

        private void UpdateState()
        {
            if(stateObject != null)
            {
                Destroy(stateObject);
            }

            stateObject = Instantiate(this.states.CurrentState.item.Prefab, transform);
        }
    }
}
