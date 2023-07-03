using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationManager : Singleton<ReputationManager>
{
    [SerializeField]
    ReputationConfig config;
    public ReputationConfig Config {
        get { return config; }
    }

    public void NotifyActionCommitted(Action action)
    {
        int score = config.GetAbsoluteImpactScore(action);
        int i = config.GetPeopleId(action.Instigator.GetPeople());
        int j = config.GetPeopleId(action.Target.GetPeople());

        config.AddReputationScore(score, i, j);
    }
}
