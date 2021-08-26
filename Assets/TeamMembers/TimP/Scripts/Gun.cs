using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;


namespace Tim
{
    public class Gun : NetworkBehaviour
    {
        public Vector3 currentPos;
        public GameObject bullet;
        public NetworkIdentity playerIdentity;
        public bool isShooting;
        public float timeForShoot = .2f;
        public List<GameObject> pooledObjects = new List<GameObject>();
        public int amountToPool;

        public override void OnStartServer()
        {
            base.OnStartServer();
            //pooledObjects = new List<GameObject>();
            GameObject tmp;
            for (int i = 0; i < amountToPool; i++)
            {
                RpcRequestShoot();
            }
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < amountToPool; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            return null;
        }
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
                    //CmdRequestShoot();
                    CmdShoot();
                    isShooting = false;
                }
            }
        }
        [ClientRpc]
        void RpcRequestShoot()
        {
            GameObject bulletInstantiate = Instantiate(bullet,currentPos,transform.rotation);
            bulletInstantiate.GetComponent<Bullet>().ownerIdentity = playerIdentity;
            NetworkServer.Spawn(bulletInstantiate);
            pooledObjects.Add(bulletInstantiate);
            bulletInstantiate.SetActive(false);
        }
        [Command(requiresAuthority = true)]
        void CmdShoot()
        {
            GameObject bullet = GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
            }
        }
    }
}
