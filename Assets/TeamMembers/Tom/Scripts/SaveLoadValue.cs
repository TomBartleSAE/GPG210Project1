using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tom
{
    public class SaveLoadValue : MonoBehaviour
    {
        public SaveLoadTestValues test;

        public void SaveValue()
        {
            string save = JsonUtility.ToJson(test, true);
            PlayerPrefs.SetString("Settings", save);
        }
        
        public void LoadValue()
        {
            string load = PlayerPrefs.GetString("Settings");
            JsonUtility.FromJsonOverwrite(load, test);
        }
    }
}