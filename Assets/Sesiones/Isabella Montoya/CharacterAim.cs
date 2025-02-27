using Cinemachine;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class CharacterAim : MonoBehaviour, ICharacterComponent
{
    [SerializeField] private CinemachineVirtualCamera aimingCamera;
    [SerializeField] private AimConstraint aimConstraint;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void OnAim(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            //apuntar
            aimingCamera?.gameObject.SetActive(true);
            ParentCharacter.IsAiming=true;
            aimConstraint.weight=1;
            anim.SetLayerWeight(1, 1);
        }
        if(ctx.canceled)
        {
            //dejar de apuntar
            aimingCamera?.gameObject.SetActive(false);
            ParentCharacter.IsAiming = false;
            aimConstraint.weight = 0;
            anim.SetLayerWeight(1, 0);
        }
    }

    public Character ParentCharacter { get; set; }
}
