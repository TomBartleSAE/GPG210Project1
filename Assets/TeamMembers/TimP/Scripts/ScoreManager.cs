using System.Collections;
using System.Collections.Generic;
using Mirror;
using Tom;
using UnityEngine;

public class ScoreManager : NetworkBehaviour
{
    //public GameObject asteroids;

    private Health[] health;
    // Start is called before the first frame update
   
    public override void OnStartServer()
    {
        base.OnStartServer();
        if (isServer)
        {
            health = FindObjectsOfType<Health>();
            foreach (Health h in health)
            {
                h.OnDeathEvent += RpcScore;
            }
            
        }
    }

    [ClientRpc]
    private void RpcScore()
    {
        Debug.Log("Adding Score");
    }
}
