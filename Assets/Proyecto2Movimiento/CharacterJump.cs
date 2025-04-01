using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class CharacterJump : MonoBehaviour, ICharacterComponent
{
    private Animator anim;
    

    // Start is called before the first frame update

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (!ctx.started && !ctx.canceled) return;
        ParentCharacter.IsJumping = ctx.started;


    }

   

    public Character ParentCharacter { get; set; }

}
