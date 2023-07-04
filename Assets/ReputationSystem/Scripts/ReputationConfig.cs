using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReputationConfig", menuName = "ReputationSystem/ReputationConfig", order = 0)]
public class ReputationConfig : ScriptableObject 
{
    [SerializeField]
    People[] peoples;

    [SerializeField]
    PeopleReputation[] peopleReputation;
    
    [SerializeField]
    ActionImpactScore[] directImpactScores;
    public ActionImpactScore[] DirectImpactScores
    {
        get { return directImpactScores; }
    }
    
    [SerializeField]
    ActionImpactScore[] indirectImpactScores;
    public ActionImpactScore[] IndirectImpactScores
    {
        get { return indirectImpactScores; }
    }

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

    public bool DoesLike(People people, People other)
    {
        int i = GetPeopleId(people);
        int j = GetPeopleId(other);

        return GetReputation(i,j) > 0;
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