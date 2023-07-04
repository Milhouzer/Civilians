using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Individual : MonoBehaviour
{
    [SerializeField]
    private People people;
    public People GetPeople() {
        return people;
    }

    public void CommitAction(Individual target, ActionImpact impact, ActionMorality absoluteMorality)
    {
        Action action = new Action(this, target, impact, absoluteMorality);
        CommitAction(action);
    }

    private void CommitAction(Action action)
    {
        ReputationManager.Instance.ActionCommitted(action);
        List<Individual> witnesses = Individual.GetWitnesses(this, 2f);
        foreach(Individual witness in witnesses)
        {
            if(witness != this && witness != action.Target)
                witness.WitnessAction(action);
        }
    }

    public void WitnessAction(Action action)
    {
        ReputationManager.Instance.ActionWitnessed(action, this);
    }

    public static List<Individual> GetWitnesses(Individual center, float radius)
    {
        List<Individual> witnesses = new List<Individual>();
        Vector3 centerPoint = center.transform.position;
        
        Collider[] colliders = Physics.OverlapSphere(centerPoint, radius);

        foreach (Collider collider in colliders)
        {
            Individual individual = collider.GetComponent<Individual>();

            if (individual != null)
            {
                witnesses.Add(individual);
            }
        }

        return witnesses;
    }
}
