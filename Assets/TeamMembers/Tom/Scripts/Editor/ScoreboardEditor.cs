using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tom
{
    [CustomEditor(typeof(Scoreboard))]
    public class ScoreboardEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Add Player"))
            {
                ((Scoreboard)target).AddPlayer();
            }
        }
    }
}