using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Tim
{
    public class Gun : NetworkBehaviour
    {
        public Vector3 cPos;
        public GameObject bullet;
        public NetworkIdentity playerIdentity;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        
        void Update()
        {
            cPos = transform.localPosition;
            ClientStuff();
        }

        void ClientStuff()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                CmdRequestShoot();
            }
        }
        
        [Command(requiresAuthority = false)]
        void CmdRequestShoot()
        {
            GameObject bulletInstantiate = Instantiate(bullet,cPos,transform.rotation);
            bulletInstantiate.GetComponent<Bullet>().ownerIdentity = playerIdentity;
            NetworkServer.Spawn(bulletInstantiate);
            //RpcShoot();
        }

        [ClientRpc]
        void RpcShoot()
        {
            
        }
    }
}
