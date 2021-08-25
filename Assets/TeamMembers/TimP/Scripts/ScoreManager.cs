using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Tom;
using UnityEngine;

public class ScoreManager : NetworkBehaviour
{
    public event Action<int,NetworkIdentity> scoreEvent;

    [ClientRpc]
    public void RpcScore(int score, NetworkIdentity conn)
    {
        Debug.Log("Adding Score");
        scoreEvent?.Invoke(score,conn);
    }
    
}
