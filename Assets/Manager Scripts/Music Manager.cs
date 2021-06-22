using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public GameManager GameManager;
    public void OnEnable()
    {
        GameManager.StartGameEvent += StartMusic;
    }

    private void StartMusic()
    {
        throw new NotImplementedException();
    }
    
}
