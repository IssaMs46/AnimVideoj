using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))] 
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private FloatDampener speedX;
    [SerializeField] private FloatDampener speedY;

    private Animator animator;

    private int speedXHash;
    private int speedYHash;

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 inputValue  = ctx.ReadValue<Vector2>();
        speedX.TargetValue = inputValue.x;
        speedY.TargetValue = inputValue.y;

    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        speedXHash = Animator.StringToHash(name: "SpeedX");
        speedYHash = Animator.StringToHash(name: "SpeedY");
    }


#if UNITY_EDITOR
    private void Update()
    {
       speedX.Update();
       speedY.Update();

        animator.SetFloat(speedXHash, speedX.CurrentValue);
        animator.SetFloat(speedYHash, speedY.CurrentValue);
    }

#endif
}
