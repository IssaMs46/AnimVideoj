using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour, IDamageReceiver<SleepDamage>, IDamageReceiver<ParalysisDamage>
{
   public void ReceiveDamage(SleepDamage damage)
    {
        throw new System.NotImplementedException();
        //go to sleep
    }

    public void ReceiveDamage(ParalysisDamage damage)
    {
        throw new System.NotImplementedException();
        //paralize
    }



}
