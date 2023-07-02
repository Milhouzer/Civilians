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

    public void CommitAction(Individual target, ActionImpact impact)
    {
        Action action = new Action(this, target, impact);
        CommitAction(action);
    }

    private void CommitAction(Action action)
    {
        ReputationManager.Instance.NotifyActionCommitted(action);
    }

    public void WitnessAction(Action action)
    {

    }
}
