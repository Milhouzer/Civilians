using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReputationConfig", menuName = "ReputationSystem/ReputationConfig", order = 0)]
public class ReputationConfig : ScriptableObject {
    [SerializeField]
    People[] peoples;
    [SerializeField]
    PeopleReputation[] peopleReputation;
    [SerializeField]
    ActionImpactScore[] impactScores;

    public int[,] GetReputations()
    {
        int[,] reputations = new int[peopleReputation.Length, peopleReputation.Length];
        for (int i = 0; i < peopleReputation.Length; i++)
        {
            for (int j = 0; j < peopleReputation.Length; j++)
            {
                reputations[i,j] = peopleReputation[i].Reputations[j];
            }
        }

        return reputations;
    }

    public int GetReputation(int i, int j)
    {
        return GetReputations()[i,j];
    }

    public void SetReputation(int value, int i, int j)
    {
        peopleReputation[i].Reputations[j] = value;
    }

    public void AddReputationScore(int value, int i, int j)
    {
        peopleReputation[i].Reputations[j] += value;
    }

    public int GetAbsoluteImpactScore(Action action)
    {
        Debug.Log(action.Instigator.GetPeople() + " Likes " + action.Target.GetPeople() + " ? : " + DoesLike(action.Instigator.GetPeople(), action.Target.GetPeople()));
        ActionImpact impact = action.Impact;
        for (int i = 0; i < impactScores.Length; i++)
        {
            ActionImpactScore impactScore = impactScores[i];
            if(impact == impactScore.impact)
            {
                return impactScore.score;
            }
        }

        return 0;
    }

    public bool DoesLike(People people, People other)
    {
        int i = GetPeopleId(people);
        int j = GetPeopleId(other);

        return GetReputation(i,j) > 0;
    }

    public int GetRelativeImpactScore(Action action, People observer)
    {
        int absoluteImpactScore = GetAbsoluteImpactScore(action);
        

        return 0;
    }

    public int GetPeopleId(People people)
    {
        return Array.IndexOf(peoples, people);
    }
}

[System.Serializable]
public class ActionImpactScore
{
    public ActionImpact impact;
    public int score;
}