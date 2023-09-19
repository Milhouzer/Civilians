using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPOI<T> where T : MonoBehaviour
{
    POI<T> Poi { get; }
}
