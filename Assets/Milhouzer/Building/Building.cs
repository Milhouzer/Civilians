using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-200)]
public class Building : MonoBehaviour
{
    [SerializeField]
    private Transform entrance;
    public Transform Entrance { get => entrance; }
    
    [SerializeField]
    private Transform doorstep;
    public Transform Doorstep { get => doorstep; }

    protected virtual void Awake() 
    {
        // BuildingManager.RegisterBuilding(this);
    }
}
