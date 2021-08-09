using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Tom
{
    public class SpawnEditor : EditorWindow
    {
        public int numberToSpawn = 1;
        public Vector2 xMinMax, yMinMax;
        public GameObject objectToSpawn;

        public bool randomScaleEnabled = false;
        public Vector2 scaleRange;
        
        public List<GameObject> spawnedObjects = new List<GameObject>();

        [MenuItem("Window/Spawn Editor")]
        static void Init()
        {
            SpawnEditor spawnEditor = (SpawnEditor) EditorWindow.GetWindow(typeof(SpawnEditor));
            spawnEditor.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Spawn Settings");
            objectToSpawn = (GameObject) EditorGUILayout.ObjectField("Object To Spawn", objectToSpawn, typeof(GameObject));
            numberToSpawn = EditorGUILayout.IntField("Number To Spawn", numberToSpawn);

            xMinMax = EditorGUILayout.Vector2Field("X Min and Max", xMinMax);
            yMinMax = EditorGUILayout.Vector2Field("Y Min and Max", yMinMax);

            randomScaleEnabled = EditorGUILayout.BeginToggleGroup("Random Scale", randomScaleEnabled);
            scaleRange = EditorGUILayout.Vector2Field("Scale Min and Max", scaleRange);
            EditorGUILayout.EndToggleGroup();

            if (GUILayout.Button("Spawn Objects - Random.Range"))
            {
                if (numberToSpawn > 0)
                {
                    for (int i = 0; i < numberToSpawn; i++)
                    {
                        Vector3 spawnPosition = new Vector3(Random.Range(xMinMax.x, xMinMax.y),
                            Random.Range(yMinMax.x, yMinMax.y), 0);

                        GameObject newObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                        spawnedObjects.Add(newObject);
                        Debug.Log(spawnedObjects.Last().name);

                        if (randomScaleEnabled)
                        {
                            float randomScale = Random.Range(scaleRange.x, scaleRange.y);
                            newObject.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
                        }
                    }
                }
            }

            if (GUILayout.Button("Spawn Object - Perlin Noise"))
            {
                if (numberToSpawn > 0)
                {
                    for (int i = 0; i < numberToSpawn; i++)
                    {
                        for (int x = (int) xMinMax.x; x < (int) xMinMax.y; x++)
                        {
                            for (int y = (int) yMinMax.x; y < yMinMax.y; y++)
                            {
                                float xCoord = ((float)x - xMinMax.x) / (xMinMax.y - xMinMax.x);
                                float yCoord = ((float)y - yMinMax.x) / (yMinMax.y - yMinMax.x);

                                float perlin = Mathf.PerlinNoise(xCoord, yCoord);

                                if (perlin > 0.7f)
                                {
                                    Instantiate(objectToSpawn, new Vector3(x, y, 0), Quaternion.identity);
                                }
                            }
                        }
                    }
                }
            }

            if (GUILayout.Button("Delete Spawned"))
            {
                if (spawnedObjects.Count > 0)
                {
                    foreach (GameObject go in spawnedObjects)
                    {
                        DestroyImmediate(go);
                    }
                    
                    spawnedObjects.Clear();
                }
            }
        }

        private void OnEnable()
        {
            string load = PlayerPrefs.GetString("Spawn Editor Settings");
            JsonUtility.FromJsonOverwrite(load, this);
        }

        private void OnDisable()
        {
            string save = JsonUtility.ToJson(this);
            PlayerPrefs.SetString("Spawn Editor Settings", save);
        }
    }
}