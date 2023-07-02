using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "People", menuName = "ReputationSystem/People", order = 0)]
public class People : ScriptableObject {
    [SerializeField]
    private string peopleName;
    public string PeopleName{
        get { return peopleName; }
    }
}
