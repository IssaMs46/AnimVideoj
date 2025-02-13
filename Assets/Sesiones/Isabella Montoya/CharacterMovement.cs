using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))] 
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private FloatDampener speedX;
    [SerializeField] private FloatDampener speedY;
    [SerializeField] private float angularSpeed;

    private Animator animator;

    private int speedXHash;
    private int speedYHash;

    Quaternion targetRotation;
    private void SolveCharacterRotation()
    {
        Vector3 floorNormal = transform.up;
        Vector3 cameraRealForward = camera.transform.forward;
        float angleInterpolator = Mathf.Abs(Vector3.Dot(cameraRealForward, floorNormal));
        Vector3 cameraForward = Vector3.Lerp(cameraRealForward, camera.transform.up, angleInterpolator).normalized;
        Vector3 characterForward = Vector3.ProjectOnPlane(cameraForward, floorNormal);

        Debug.DrawLine(transform.position, transform.position + characterForward * 2, Color.magenta, 5);

        Quaternion lookRotation = Quaternion.LookRotation(characterForward, floorNormal);
        targetRotation = Quaternion.RotateTowards(transform.rotation, lookRotation, angularSpeed);
        
    }
    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 inputValue  = ctx.ReadValue<Vector2>();
        speedX.TargetValue = inputValue.x;
        speedY.TargetValue = inputValue.y;

        SolveCharacterRotation();
       // transform.rotation = targetRotation;


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

        transform.rotation= Quaternion.RotateTowards(transform.rotation, targetRotation, angularSpeed);
    }

#endif
}
