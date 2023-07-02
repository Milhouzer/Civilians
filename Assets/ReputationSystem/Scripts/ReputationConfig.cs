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

    public void SetReputation(int value, int i, int j)
    {
        peopleReputation[i].Reputations[j] = value;
    }
}

[System.Serializable]
public class ActionImpactScore
{
    public ActionImpact impact;
    public int score;
}