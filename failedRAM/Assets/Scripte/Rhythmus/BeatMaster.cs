using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatMaster : MonoBehaviour
{
    [SerializeField] private float _bpm;
    [SerializeField] private AudioSource _audio_source;
    [SerializeField] private Intervals[] _intervals; 

    private void Update()
    {
        foreach (Intervals interval in _intervals)
        {
            float sampledTime = (_audio_source.timeSamples / (_audio_source.clip.frequency * interval.GetIntervalLength(_bpm)));
            interval.CheckForNewInterval(sampledTime);
        }
    }
}

[System.Serializable] 
public class Intervals
{

    [SerializeField] private float _steps;
    [SerializeField] private UnityEvent _trigger;
    private int _lastIntervall;

    public float GetIntervalLength(float bpm)
    {
        return 60f / (bpm * _steps);
    }

    public void CheckForNewInterval (float interval)
    {
        if (Mathf.FloorToInt(interval) != _lastIntervall)
        {
            _lastIntervall = Mathf.FloorToInt(interval);
            _trigger.Invoke();
        }
    }
}
