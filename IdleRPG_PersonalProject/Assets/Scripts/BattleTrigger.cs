using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    private bool isStarted = false;
    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable;
        if(other.TryGetComponent(out damageable))
        {
            damageable.BattleOrder(true);

            if (isStarted == false)
            {
                isStarted = true;
                for (int i = 0; i < StageManager.Instance.enemys.Count; i++)
                {
                    StageManager.Instance.enemys[i].BattleOrder();
                }
            }
        }
    }
}
