using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class LobbyPlayer : NetworkBehaviour
{
    [SyncVar] public bool readyToStart;
    public bool isLobbyPlayer;
    [SyncVar] public string name;
}
