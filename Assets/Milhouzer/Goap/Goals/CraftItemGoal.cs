using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;

public class CraftItemGoal : GoalBase<CraftItemGoal.Data>
{
    
    public class Data : IGoalData
    {
        public IGoalTarget Target { get; set; }
    }
}
