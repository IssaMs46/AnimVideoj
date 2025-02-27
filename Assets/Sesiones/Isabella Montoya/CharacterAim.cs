using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterAim : MonoBehaviour, ICharacterComponent
{
    [SerializeField] private CinemachineVirtualCamera aimingCamera;
    public void OnAim(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            //apuntar
            aimingCamera?.gameObject.SetActive(true);
            ParentCharacter.IsAiming=true;

        }
        if(ctx.canceled)
        {
            //dejar de apuntar
            aimingCamera?.gameObject.SetActive(false);
            ParentCharacter.IsAiming = false;
        }
    }

    public Character ParentCharacter { get; set; }
}
