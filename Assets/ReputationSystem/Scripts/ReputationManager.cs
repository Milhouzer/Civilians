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
        
    }
}
