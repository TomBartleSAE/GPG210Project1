using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class Health : MonoBehaviour
    {
        public event Action OnDeathEvent;

        public void Die()
        {
            OnDeathEvent?.Invoke();
        }

        public event Action TakeDamageEvent;

        public void TakeDamage()
        {
            TakeDamageEvent?.Invoke();
        }
    }
}