using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class CharacterLook : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private FloatDampener horizontalDampener;
    [SerializeField] private FloatDampener verticalDampener;

    [SerializeField] private float horizontalRotationSpeed;
    [SerializeField] private float verticalRotationSpeed;

    public void OnLook(InputAction.CallbackContext ctx)
    {
        Vector2 inputValue = ctx.ReadValue<Vector2>();
      
        inputValue = inputValue / new Vector2(Screen.width, Screen.height);

        horizontalDampener.TargetValue = inputValue.x;
        verticalDampener.TargetValue = inputValue.y;
    }

    private void ApplyLookRotation()
    {
        if (target == null)
        {
            throw new NullReferenceException("Look target is null, assign it in inspector");
           
        }

        Quaternion horizontalRotation = Quaternion.AngleAxis(horizontalDampener.CurrentValue * horizontalRotationSpeed, transform.up);
        transform.rotation *= horizontalRotation;
    }

    private void Update()
    {
        horizontalDampener.Update();
        verticalDampener.Update();

        ApplyLookRotation();
    }
}
