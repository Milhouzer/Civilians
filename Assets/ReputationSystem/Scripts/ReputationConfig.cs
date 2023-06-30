using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReputationConfig", menuName = "ReputationSystem/ReputationConfig", order = 0)]
public class ReputationConfig : ScriptableObject {
    [SerializeField]
    int index;
    [SerializeField]
    List<People> peoples = new List<People>();
    [SerializeField]
    PeopleReputation[] peopleReputation;
}
