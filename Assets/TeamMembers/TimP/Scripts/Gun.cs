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
        public bool isShooting;
        public float timeForShoot = .2f;
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
            GameObject bulletInstantiate = Instantiate(bullet,cPos,transform.rotation);
            bulletInstantiate.GetComponent<Bullet>().ownerIdentity = playerIdentity;
            NetworkServer.Spawn(bulletInstantiate);
            //RpcShoot();
        }

        [ClientRpc]
        void RpcShoot()
        {
            GameObject bulletInstantiate = Instantiate(bullet,cPos,transform.rotation);
            bulletInstantiate.GetComponent<Bullet>().ownerIdentity = playerIdentity;
            NetworkServer.Spawn(bulletInstantiate);
        }
    }
}
