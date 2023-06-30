using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "People", menuName = "My project/People", order = 0)]
public class People : ScriptableObject {
    [SerializeField]
    private string PeopleName;
}
