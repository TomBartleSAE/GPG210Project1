using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameManager GameManager;

    private void OnEnable()
    {
        GameManager.StartGameEvent += SpawnAsteroids;
    }

    private void SpawnAsteroids()
    {
        throw new NotImplementedException();
    }
}
