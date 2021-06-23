using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class Health : MonoBehaviour
    {
        public event Action OnDeath;

        public void Die()
        {
            OnDeath?.Invoke();
        }
    }
}