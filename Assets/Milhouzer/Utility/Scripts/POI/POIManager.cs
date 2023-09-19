using System.Collections;
using System.Collections.Generic;
using Milhouzer.Utility;
using UnityEngine;

public class POIManager : Singleton<POIManager>
{
    Dictionary<string, List<GameObject>> poiDB = new Dictionary<string, List<GameObject>>(); 

    public void RegisterPOI<T>(GameObject gameObject)
    {
        string key = typeof(T).ToString();
        if(poiDB.ContainsKey(key))
        {
            poiDB[key].Add(gameObject);
        }
        else
        {
            poiDB.Add(key, new List<GameObject>() {gameObject});
        }
    } 

    public void UnRegisterPOI<T>(GameObject gameObject)
    {

    } 
}
