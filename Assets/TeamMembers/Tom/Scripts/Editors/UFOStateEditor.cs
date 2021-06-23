using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Tom
{
    [CustomEditor(typeof(UFO))]
    public class UFOStateEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Change to Flying"))
            {
                ((UFO)target).GetComponent<StateManager>().ChangeState(((UFO)target).flyingState);
            }
            
            if (GUILayout.Button("Change to Shooting"))
            {
                ((UFO)target).GetComponent<StateManager>().ChangeState(((UFO)target).shootingState);
            }
            
            if (GUILayout.Button("Change to Dead"))
            {
                ((UFO)target).GetComponent<StateManager>().ChangeState(((UFO)target).deadState);
            }
            
            GUILayout.EndHorizontal();
        }
    }
}