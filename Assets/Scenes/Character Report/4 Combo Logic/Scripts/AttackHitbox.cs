using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour, IDamageSender<DamageMessage>
{

    [SerializeField] private float damage;


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamageReceiver<DamageMessage> receiver))
        {
            SendDamage(receiver);
        }
    }
    public void SendDamage(IDamageReceiver<DamageMessage> receiver)
    {
        DamageMessage message = new DamageMessage
        {
            sender = transform.root.gameObject,
            amount = damage
        };
        receiver.ReceiveDamage(message);
    }
 
}
