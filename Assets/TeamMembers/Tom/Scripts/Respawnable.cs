using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Tom;
using UnityEngine;
using Random = UnityEngine.Random;

public class Respawnable : MonoBehaviour
{
    private Health health;
    public float respawnTime = 3f;
    
    private void Awake()
    {
        health = GetComponent<Health>();
    }

    public void StartRespawn()
    {
        if (health.lives > 0)
        {
            StartCoroutine(Respawn());
        }
        else
        {
            // Destroy player
            NetworkServer.Destroy(gameObject);
        }
    }

    public IEnumerator Respawn()
    {
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(respawnTime);
        transform.position = new Vector3(Random.Range(-40f, 40f), 0, Random.Range(-40f, 40f));
        StartCoroutine(health.SetInvincibility(2f));
        health.health = default;
        GetComponent<Collider>().enabled = true;
        GetComponentInChildren<MeshRenderer>().enabled = true;
    }

    private void OnEnable()
    {
        health.OnDeathEvent += StartRespawn;
    }
}
