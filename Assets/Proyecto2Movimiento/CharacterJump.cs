using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class CharacterJump : MonoBehaviour, ICharacterComponent
{
    private Animator anim;
    private Rigidbody rb;

    [SerializeField] private float jumpForce = 5f;

    // Start is called before the first frame update

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (!ctx.started && !ctx.canceled) return;

        Debug.Log("OnJump called"); // Verificación de que el método se ejecuta

        if (ctx.started && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump");
            ParentCharacter.IsJumping = true;
        }

        if (ctx.canceled)
        {
            ParentCharacter.IsJumping = false;
        }

    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }


    public Character ParentCharacter { get; set; }

}
