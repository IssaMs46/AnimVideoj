using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] 
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;

    private Animator animator;

    private int speedXHash;
    private int speedYHash;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        speedXHash = Animator.StringToHash(name: "speedX");
        speedYHash = Animator.StringToHash(name: "speedY");
    }


#if UNITY_EDITOR
    private void Update()
    {
       
        animator.SetFloat(name:"SpeedX", speedX);
        animator.SetFloat(name: "SpeedY", speedY);
    }

#endif
}
