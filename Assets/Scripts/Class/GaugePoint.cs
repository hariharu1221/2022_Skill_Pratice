using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GaugePoint
{
    [SerializeField] public float MaxGaugeBar;

    [SerializeField] private float _gaugeBar;
    public float GaugeBar
    {
        get { return _gaugeBar; }
        set 
        {
            if (_gaugeBar > MaxGaugeBar) _gaugeBar = MaxGaugeBar;
            else if (_gaugeBar < -5) _gaugeBar = -5;
            else _gaugeBar = value; 
        }
    }

    public bool Check()
    {
        if (_gaugeBar <= 0) return false;
        return true;
    }

    public GaugePoint(float maxGaugeBar, float setGaugeBar)
    {
        MaxGaugeBar = maxGaugeBar;
        _gaugeBar = setGaugeBar;
    }
}
