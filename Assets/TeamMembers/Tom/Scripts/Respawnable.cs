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
    }

    public IEnumerator Respawn()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        transform.position = new Vector3(Random.Range(-40f, 40f), 0, Random.Range(-40f, 40f));
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        health.OnDeathEvent += StartRespawn;
    }
}
