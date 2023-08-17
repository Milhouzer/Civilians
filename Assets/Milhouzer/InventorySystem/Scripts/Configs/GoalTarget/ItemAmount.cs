using CrashKonijn.Goap.Interfaces;

namespace Milhouzer.InventorySystem
{
    public class ItemAmount : IGoalTarget
    {
        public Item item;
        public int amount;

        public ItemAmount(Item item, int amount)
        {
            this.item = item;
            this.amount = amount;
        }

        public void GetTarget(out object target)
        {
            target = item;
        }

        public bool IsReached(IComponentReference references)
        {
            Inventory inventory = references.GetCachedComponent<Inventory>();
            return inventory.HasItem(item);
        }
    }
}
