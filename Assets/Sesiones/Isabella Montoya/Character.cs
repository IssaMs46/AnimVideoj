using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class Character : MonoBehaviour
{
    [SerializeField] Transform lockTarget;

    public Transform LockTarget
    {
        get => LockTarget;
        set => LockTarget =value;
    }

    private void RegisterComponents()
    {
        foreach (ICharacterComponent characterComponent in GetComponentsInChildren<ICharacterComponent>())
        {
            characterComponent.ParentCharacter = this;
        }
    }

    private void Awake()
    {
        RegisterComponents();
    }
}
