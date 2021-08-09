using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Tom;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tim
{
    

public class Spawner : NetworkBehaviour
{
    public GameObject asteroid;
    private Vector3 cPos;

    public SpawnManager spawnManager;
    public bool startSpawn = false;

    public override void OnStartServer()
    {
        base.OnStartServer();
        startSpawn = true;
        spawnManager.SpawnObstacles += SpawnOnServerStart;
        cPos = new Vector3(transform.position.x+Random.Range(0,10), .5f, transform.position.z+Random.Range(0,10));
        //this.asteroidSpawn(asteroid,cPos);
    }

    private void SpawnOnServerStart()
    {
        //this.asteroidSpawn(asteroid,cPos);
        if (startSpawn == true)
        {
            StartCoroutine(asteroidSpawn(asteroid, cPos));
        }
    }

    /*public void asteroidSpawn(GameObject aGame,Vector3 aSpawn)
      {
        GameObject asteroidSpawn = Instantiate(aGame, aSpawn, Quaternion.identity);
        NetworkServer.Spawn(asteroidSpawn);
      }*/

    private void FixedUpdate()
    {
        if (startSpawn == true)
        {
            StartCoroutine(asteroidSpawn(asteroid, cPos));
        }
        
    }

    public IEnumerator asteroidSpawn(GameObject aGame, Vector3 aSpawn)
    {
        startSpawn = false;
        GameObject asteroidSpawn = Instantiate(aGame, aSpawn, Quaternion.identity);
        NetworkServer.Spawn(asteroidSpawn);
        Debug.Log("test spawn");
        yield return new WaitForSeconds(20f);
        startSpawn = true;
    }
}
}
