using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterState))]
public class AttackController : MonoBehaviour
{

    [SerializeField] private float lightAttackCost;
    [SerializeField] private float heavyAttackCost;

    private Animator anim;

    private CharacterState characterState;

    private void Awake()
    {
        anim= GetComponent<Animator>();
        characterState= GetComponent<CharacterState>();
    }
    public void OnLightAttack(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            anim.SetTrigger("LightAttack");
        }
    }

    public void OnHeavyAttack(CallbackContext ctx)
    {
        if (ctx.performed || ctx.canceled)
        {
            anim.SetTrigger("HeavyAttack");
        }
    }
}
