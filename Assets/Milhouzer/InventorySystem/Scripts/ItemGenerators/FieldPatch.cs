using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Milhouzer.Interfaces;
using Milhouzer.Utility;

namespace Milhouzer.InventorySystem
{
    public class FieldPatch : InteractableBase, IPOI<FieldPatch>
    {
        private POI<FieldPatch> poi;
        public POI<FieldPatch> Poi => poi;

        IItemGenerator itemGenerator;

        protected override void Awake()
        {
            poi = new POI<FieldPatch>(gameObject);
            itemGenerator = GetComponent<IItemGenerator>();

            base.Awake();
        }

        public override void Interact(GameObject interactor)
        {
            base.Interact(interactor);
            itemGenerator.Generate();
        }
    }
}