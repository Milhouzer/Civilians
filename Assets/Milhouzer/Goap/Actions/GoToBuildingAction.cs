using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using UnityEngine;

public class GoToBuildingAction<T> : ActionBase<GoToBuildingAction<T>.Data>
    where T : Building
{
        public override void Created()
        {
        }

        public override void Start(IMonoAgent agent, Data data)
        {
            data.RemainingDistance = Vector3.Distance(agent.transform.position, data.Target.Position);
            
            if (data.Target is not TransformTarget transformTarget)
                return;
            
            data.TargetBuilding =  transformTarget.Transform.GetComponent<Building>();
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            data.RemainingDistance = Vector3.Distance(agent.transform.position, data.Target.Position);
            
            if (data.RemainingDistance > 0.5f)
                return ActionRunState.Continue;
            
            return ActionRunState.Stop;
        }

        public override void End(IMonoAgent agent, Data data)
        {
            Civilian civilian = agent.GetComponent<Civilian>();
            civilian.TargetBuilding = data.TargetBuilding;
        }

        public class Data : IActionData
        {
            public ITarget Target { get; set; }
            public float RemainingDistance { get; set; }
            public Building TargetBuilding { get; set; }
        }
}
