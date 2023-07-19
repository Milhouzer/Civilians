using Milhouzer.InventorySystem;

namespace CrashKonijn.Goap.Interfaces
{
    public interface IItemActionData : IActionData
    {
        public Item item { get; set; }
    }
}