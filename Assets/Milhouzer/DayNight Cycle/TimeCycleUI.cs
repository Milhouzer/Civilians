using UnityEngine;
using System;
using TMPro;

public class TimeCycleUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentTime;

    void Start()
    {
        TimeCycle.OnTick += OnTimeChanged;
    }

    void OnTimeChanged(DateTime time)
    {
        currentTime.text = time.Hour + ":" + time.Minute;
    }
}
