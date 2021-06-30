using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Tom
{
    public class Health : NetworkBehaviour
    {
        public event Action OnDeathEvent;

        public void Die()
        {
            OnDeathEvent?.Invoke();
        }

        public event Action<int> TakeDamageEvent;

        public void TakeDamage(int damage)
        {
            TakeDamageEvent?.Invoke(damage);
        }
    }
}