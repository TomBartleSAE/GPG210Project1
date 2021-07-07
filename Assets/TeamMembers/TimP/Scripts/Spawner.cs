using System.Collections;
using System.Collections.Generic;
using Mirror;
using Tom;
using UnityEngine;

namespace Tim
{
    

public class Spawner : NetworkBehaviour
{
    public GameObject asteroid;
    private Vector3 cPos;

    public SpawnManager spawnManager;

    public override void OnStartServer()
    {
        base.OnStartServer();
        spawnManager.SpawnObstacles += SpawnOnServerStart;
        cPos = new Vector3(transform.position.x+Random.Range(0,10), .5f, transform.position.z+Random.Range(0,10));
        //this.asteroidSpawn(asteroid,cPos);
    }

    private void SpawnOnServerStart()
    {
        this.asteroidSpawn(asteroid,cPos);
    }

    public void asteroidSpawn(GameObject aGame,Vector3 aSpawn)
    {
        GameObject asteroidSpawn = Instantiate(aGame, aSpawn, Quaternion.identity);
        NetworkServer.Spawn(asteroidSpawn);
    }
}
}
