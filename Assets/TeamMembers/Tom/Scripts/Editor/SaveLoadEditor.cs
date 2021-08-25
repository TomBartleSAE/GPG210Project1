using System.Collections;
using System.Collections.Generic;
using Tom;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SaveLoadValue))]
public class SaveLoadEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Save"))
        {
            ((SaveLoadValue) target).SaveValue();
        }

        if (GUILayout.Button("Load"))
        {
            ((SaveLoadValue) target).LoadValue();
        }

        GUILayout.EndHorizontal();
    }
}