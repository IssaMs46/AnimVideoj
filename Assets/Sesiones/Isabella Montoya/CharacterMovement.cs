using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] 
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;

    private Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


#if UNITY_EDITOR
    private void OnValidate()
    {
        animator.SetFloat(name:"speedX", speedX);
        animator.SetFloat(name: "SpeedY", speedY);
    }

#endif
}
