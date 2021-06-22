using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class EditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        DrawDefaultInspector();

        GameManager gameManager = (GameManager) target;
        
        if (GUILayout.Button("Death Test"))
        {
            gameManager.Death();
        }

        if (GUILayout.Button("Start Game"))
        {
            gameManager.StartGame();
        }

        if (GUILayout.Button("End Game"))
        {
            gameManager.EndGame();
        }
    }

}
