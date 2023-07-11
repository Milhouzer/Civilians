using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingArea : MonoBehaviour
{
    public Building building;

    void Awake()
    {
        building = GetComponentInParent<Building>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other + " enters " + this);
        Civilian civilian = other.GetComponent<Civilian>();
        if(civilian)
        {
            civilian.EnterArea(this);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        Debug.Log(other + " exits " + this);
        
        Civilian civilian = other.GetComponent<Civilian>();
        if(civilian)
        {
            civilian.ExitArea(this);
        }
    }
}
