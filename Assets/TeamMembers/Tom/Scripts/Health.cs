using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Tom
{
    public class Health : NetworkBehaviour
    {
        public int health = 1;
        
        public event Action OnDeathEvent;

        public void CallDeathEvent()
        {
            OnDeathEvent?.Invoke();
        }

        public event Action<int> TakeDamageEvent;

        public void CallDamageEvent(int damage)
        {
            TakeDamageEvent?.Invoke(damage);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                CallDeathEvent();
            }
        }

        private void OnEnable()
        {
            TakeDamageEvent += TakeDamage;
        }

        private void OnDisable()
        {
            TakeDamageEvent -= TakeDamage;
        }
    }
}