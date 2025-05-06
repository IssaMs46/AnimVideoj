using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHitbox : MonoBehaviour, IDamageReceiver<DamageMessage>
{
   public void ReceiveDamage(DamageMessage damage)
    {
        if(damage.sender == transform.root.gameObject)
        {
            return;
        }
        //acceder al estado del jugador
        Game.Instance.PlayerOne.DepleteHealth(damage.amount);
        //reducir vida

    }
}
