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
        public int lives = 3;
        private bool invincible = false;
        
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
            if (!invincible)
            {
                health -= damage;

                if (health <= 0)
                {
                    lives--;
                    CallDeathEvent();
                }
            }
        }

        public IEnumerator SetInvincibility(float duration)
        {
            invincible = true;
            yield return new WaitForSeconds(duration);
            invincible = false;
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