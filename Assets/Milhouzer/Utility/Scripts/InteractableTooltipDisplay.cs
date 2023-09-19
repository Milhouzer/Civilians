using System.Collections;
using System.Collections.Generic;
using Milhouzer.Interfaces;
using Milhouzer.Utility;
using UnityEngine;

namespace Milhouzer
{
    public class InteractableTooltipDisplay : MonoBehaviour
    {
        [SerializeField]
        private GameObject tooltip;
        private InteractableBase interactable;

        private void Start() 
        {
            interactable = GetComponent<InteractableBase>();
            if(interactable != null)
            {
                interactable.OnCameInRange += Show;
                interactable.OnCameOutOfRange += Hide;
            }
        }

        public void Show()
        {
            tooltip.SetActive(true);
        }

        public void Hide()
        {
            tooltip.SetActive(false);
        }
    }
}
