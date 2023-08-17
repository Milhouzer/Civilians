using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Milhouzer.Utility;

public class ReputationManager : Singleton<ReputationManager>
{
    [SerializeField]
    ReputationConfig config;
    public ReputationConfig Config {
        get { return config; }
    }

    public virtual void ActionCommitted(Action action)
    {
        int score = GetAbsoluteImpactScore(action);
        int i = config.GetPeopleId(action.Instigator.GetPeople());
        int j = config.GetPeopleId(action.Target.GetPeople());

        config.AddReputationScore(score, i, j);
    }

    public virtual void ActionWitnessed(Action action, Individual witness)
    {
        int score = GetRelativeImpactScore(action, witness);
        int i = config.GetPeopleId(action.Instigator.GetPeople());
        int j = config.GetPeopleId(action.Target.GetPeople());

        config.AddReputationScore(score, i, j);
    }
    

    public int GetAbsoluteImpactScore(Action action)
    {
        ActionImpact impact = action.Impact;
        for (int i = 0; i < config.DirectImpactScores.Length; i++)
        {
            ActionImpactScore impactScore = config.DirectImpactScores[i];
            if(impact == impactScore.impact)
            {
                return impactScore.score;
            }
        }

        return 0;
    }

    public virtual int GetRelativeImpactScore(Action action, Individual witness)
    {
        int score = GetAbsoluteImpactScore(action);
        
        People instigatorPeople = action.Instigator.GetPeople();
        People targetPeople = action.Target.GetPeople();

        bool witnessLikesTarget = config.DoesLike(witness.GetPeople(), targetPeople);
        bool witnessLikesInstigator = config.DoesLike(witness.GetPeople(), instigatorPeople);

        if(action.AbsoluteMorality == ActionMorality.Wrong)
        {
            if(witnessLikesTarget)
            {

            }
            else
            {

            }
        }
        else
        {
            if(witnessLikesTarget)
            {

            }
            else
            {

            }
        }

        return 0;
    }
    
    public virtual void ApplyMorality(ActionMorality morality, ref int score)
    {
        score *= morality == ActionMorality.Wrong ? -1 : 1;
    }
}
