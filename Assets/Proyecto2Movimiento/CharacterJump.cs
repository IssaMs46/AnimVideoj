using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class CharacterJump : MonoBehaviour, ICharacterComponent
{
    private Rigidbody rb;
    private Animator anim;
    [SerializeField] private float jumpForce = 5f;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Verifica si el personaje está en el suelo
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // Si el personaje está en el suelo, desactiva la animación de salto
        if (isGrounded)
        {
            anim.SetBool("Jump", false);
        }
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started && isGrounded) // Solo salta si está en el suelo
        {
            Debug.Log("Jumping!");
            anim.SetBool("Jump", true);
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public Character ParentCharacter { get; set; }
}
