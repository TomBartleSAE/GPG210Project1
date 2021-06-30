using System.Collections;
using System.Collections.Generic;
using Mirror;
using Tom;
using UnityEngine;

public class ScoreManager : NetworkBehaviour
{
    //public GameObject asteroids;

    private Health health;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }
    public override void OnStartServer()
    {
        base.OnStartServer();
        if (isServer)
        {
            health = FindObjectOfType<Health>();
            health.OnDeathEvent += RpcScore;
        }
    }

    [ClientRpc]
    private void RpcScore()
    {
        Debug.Log("Adding Score");
    }
}
