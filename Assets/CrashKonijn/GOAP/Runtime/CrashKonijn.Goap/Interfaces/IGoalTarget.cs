
using UnityEngine;

namespace CrashKonijn.Goap.Interfaces
{
    public interface IGoalTarget
    {
        public void GetTarget(out object target);
        public bool IsReached(IComponentReference references);
    }
}