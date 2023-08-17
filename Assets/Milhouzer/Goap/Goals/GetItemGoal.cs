using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;

public class GetItemGoal : GoalBase<GetItemGoal.Data>
{
    
    public class Data : IGoalData
    {
        public IGoalTarget Target { get; set; }
    }
}
