using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POI<T> where T : MonoBehaviour
{
    GameObject gameObject;

    public POI(GameObject gameObject)
    {
        this.gameObject = gameObject;
        RegisterPOI();
    }

    void RegisterPOI()
    {
        POIManager.Instance.RegisterPOI<T>(this.gameObject);
    }
}
