using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookTarget : MonoBehaviour, ICharacterComponent
{
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask detectionMask;
    [SerializeField] private float detectionRadius;
    [SerializeField] private float detectionAngle;
    public void Lock(InputAction.CallbackContext ctx)
    {
        if (!ctx.started) return;
        Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectionRadius,detectionMask);
        if(detectedObjects.Length == 0 ) return;

        float nearestAngle = detectionAngle;
        float nearestDistance = detectionRadius;
        int closestObject;
        Vector3 cameraForward = camera.transform.forward;

        for (int i = 0; i < detectedObjects.Length; i++)
        {
            Collider obj = detectedObjects[i];
            Vector3 objViewDirection = obj.transform.position - camera.transform.position;
            float dot = Vector3.Dot(cameraForward, objViewDirection.normalized);
            float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
            if (angle > detectionAngle) continue;
            float distance = Vector3.Distance(obj.transform.position, transform.position);

            if (distance < nearestDistance && angle < nearestAngle)
                closestObject = i;

            nearestDistance = Mathf.Min(nearestDistance, distance);
            nearestAngle= Mathf.Min(angle, nearestAngle);

           
        }

        ParentCharacter.Locktarge = detectedObjects[closestObject].transform;
    }



    private void Update()
    {
        
    }
}
