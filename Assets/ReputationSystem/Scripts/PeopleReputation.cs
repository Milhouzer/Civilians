using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PeopleReputation
{
    [SerializeField]
    private int[] reputations;
    public int[] Reputations{
        get { return reputations; }
        set { reputations = value; }
    }
}
