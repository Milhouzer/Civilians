using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Enums;
using UnityEngine;

public class EnterBuildingAction<T> : ActionBase<EnterBuildingAction<T>.Data>
    where T : Building
{
        public override void Created()
        {
        }

        public override void Start(IMonoAgent agent, Data data)
        {
            data.Timer = Random.Range(0.3f, 1f);
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            data.Timer += context.DeltaTime;
            
            if (data.Timer > 0)
                return ActionRunState.Continue;
            
            return ActionRunState.Stop;
        }

        public override void End(IMonoAgent agent, Data data)
        {
        }

        public class Data : IActionData
        {
            public ITarget Target { get; set; }
            public Building building;
            public float Timer { get; set; }
        }
}

