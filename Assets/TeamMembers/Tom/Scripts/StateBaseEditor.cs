using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Tom
{
    [CustomEditor(typeof(StateBase), true)]
    public class StateBaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();

            if (GUILayout.Button("Force Enter"))
            {
                ((StateBase)target).Enter(); // Cast target as StateBase, gives access to StateBase functions
            }

            if (GUILayout.Button("Force Execute"))
            {
                ((StateBase)target).Execute();
            }

            if (GUILayout.Button("Force Exit"))
            {
                ((StateBase)target).Exit();
            }
        }
    }
}
