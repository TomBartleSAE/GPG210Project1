using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tom
{
    [CustomEditor(typeof(Health))]
    public class HealthEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Force Die"))
            {
                ((Health)target).CallDeathEvent();
            }
            
            if (GUILayout.Button("Force Damage"))
            {
                ((Health)target).CallDamageEvent(1);
            }
        }
    }
}