
using System;
using UnityEngine;

[Serializable]
public struct FloatDampener
{

    [SerializeField] private float smoothTime;

    private float currentValue;
    public float TargetValue{ get; set; }
    private float currentVelocity;
    public float CurrentValue { get; private set; }

    


    public void Update()
    {
        CurrentValue = Mathf.SmoothDamp(CurrentValue,TargetValue, ref currentVelocity, smoothTime );
    }

    
}
