using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day : MonoBehaviour
{
    Calendar calendar;
    
    private void Start() {
        calendar = GetComponentInParent<Calendar>();
    }
}
