using System.Collections;
using System.Collections.Generic;
using Mirror;
using Tom;
using UnityEngine;

public class Spawner : NetworkBehaviour
{
    public GameObject asteroid;
    private Vector3 cPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cPos = new Vector3(Random.Range(0,10), Random.Range(0,10), 0);
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        cPos = new Vector3(Random.Range(0,10), .5f, Random.Range(0,10));
        GameObject asteroidSpawn = Instantiate(asteroid,cPos,transform.rotation);
        NetworkServer.Spawn(asteroidSpawn);
    }
}
