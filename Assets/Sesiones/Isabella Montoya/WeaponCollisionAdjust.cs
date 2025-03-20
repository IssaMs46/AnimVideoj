using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollisionAdjust : MonoBehaviour
{
    struct RayResult
    {
        public Ray ray;
        public bool result;
        public RaycastHit hitInfo;
    }

    [SerializeField] private Transform handIk;

    [SerializeField] private Transform weaponReference;
    [SerializeField] private float weaponLenght;
    [SerializeField] private float profileThickness;

    [SerializeField] private LayerMask layerMask;

    private Animator anim;
    RayResult rayResult;
    private float offset;

    private void SolveOffset()
    {
        RayResult result = new RayResult();
        result.ray = new Ray(weaponReference.position, weaponReference.forward);
        result.result = Physics.SphereCast(result.ray, profileThickness, out result.hitInfo, weaponLenght, layerMask);
        rayResult = result;

        offset  = Mathf.Max(0, weaponLenght  -  Vector3.Distance(rayResult.hitInfo.point , weaponReference.position)) * -1;

    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SolveOffset();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        Vector3 originalIKPosition = anim.GetIKPosition(AvatarIKGoal.RightHand);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
       // anim.SetIKPosition(AvatarIKGoal.RightHand, originalIKPosition * weaponReference.forward  * offset); 
    }


    private void Update()
    {
        handIk.Translate(transform.forward * offset);
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {

        if (weaponReference == null) return;

        Vector3 startPos = weaponReference.position;
        Vector3 endPos = startPos + weaponReference.forward * weaponLenght;
        Gizmos.DrawWireSphere(startPos, profileThickness);
        Gizmos.DrawWireSphere(endPos, profileThickness);
        Gizmos.DrawLine(startPos, endPos);

    }
#endif

}
