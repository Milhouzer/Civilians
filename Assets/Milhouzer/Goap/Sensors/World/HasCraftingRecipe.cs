using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;


public class HasCraftingRecipe : LocalWorldSensorBase
{
    public override void Created()
    {
    }

    public override void Update()
    {
    }

    public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
    {
        // AgentBehaviour agentBehaviour = references.GetCachedComponent<AgentBehaviour>();
        
        // if (agentBehaviour == null)
        //     return false;

        
        // Debug.Log(civilian.IsInArea<T>(BuildingEnums.AreaType.Inside));
        // return civilian.IsInArea<T>(BuildingEnums.AreaType.Inside);
        return false;
    }
}

