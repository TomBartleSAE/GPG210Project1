using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Tim
{
    public class Gun : NetworkBehaviour
    {
        public Vector3 currentPos;
        public GameObject bullet;
        public NetworkIdentity playerIdentity;
        public bool isShooting;
        public float timeForShoot = .2f;
        
        void Update()
        {
            currentPos = transform.localPosition;
            ClientShoot();
        }
        
        void ClientShoot()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                //CmdRequestShoot();
                //RpcShoot();
                StartCoroutine(Firing());
            }
            
        }

        IEnumerator Firing()
        {
            if (isShooting == false)
            {
                isShooting = true;
                if (isShooting == true)
                {
                    
                    yield return new WaitForSeconds(timeForShoot);
                    CmdRequestShoot();
                    isShooting = false;
                }
            }
            
        }
        
        [Command(requiresAuthority = true)]
        void CmdRequestShoot()
        {
            GameObject bulletInstantiate = Instantiate(bullet,currentPos,transform.rotation);
            bulletInstantiate.GetComponent<Bullet>().ownerIdentity = playerIdentity;
            NetworkServer.Spawn(bulletInstantiate);
            //RpcShoot();
        }

        [ClientRpc]
        void RpcShoot()
        {
            GameObject bulletInstantiate = Instantiate(bullet,currentPos,transform.rotation);
            bulletInstantiate.GetComponent<Bullet>().ownerIdentity = playerIdentity;
            NetworkServer.Spawn(bulletInstantiate);
        }
    }
}
