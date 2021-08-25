using System;
using System.Collections;
using System.Collections.Generic;
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
        }
    }

    public IEnumerator Respawn()
    {
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(respawnTime);
        transform.position = new Vector3(Random.Range(-40f, 40f), 0, Random.Range(-40f, 40f));
        health.SetInvincibility(2);
        health.health = default;
        GetComponent<Collider>().enabled = true;
        GetComponentInChildren<MeshRenderer>().enabled = true;
    }

    private void OnEnable()
    {
        health.OnDeathEvent += StartRespawn;
    }
}
