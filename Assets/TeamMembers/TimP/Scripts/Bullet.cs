using System;
using Mirror;
using Tom;
using UnityEngine;

namespace Tim
{
    public class Bullet : NetworkBehaviour
    {
        public Rigidbody rb;
        public GameObject Asteroid;
        public float dTimer;
        public NetworkIdentity ownerIdentity;

        private ScoreManager sm;

        // Start is called before the first frame update
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            sm = FindObjectOfType<ScoreManager>();
        }

        public void OnEnable()
        {
            rb.AddRelativeForce(new Vector3(0, 0, 5), ForceMode.Impulse);
            Debug.Log(rb.velocity);
        }

        public void OnDisable()
        {
            dTimer = 4f;
            rb.velocity = Vector3.zero;
        }


        // Update is called once per frame
        private void FixedUpdate()
        {
            dTimer = dTimer - Time.deltaTime;
            if (dTimer <= 0f)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("Hit Asteroid");
                gameObject.SetActive(false);
                if (other.GetComponent<Health>())
                {
                    other.GetComponent<Health>().CallDamageEvent(1);
                }
            }

//move to player
            if (other.gameObject.GetComponent<NetworkIdentity>() != ownerIdentity &&
                other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Hit Player");
            }

            if (other.GetComponent<ScoreGive>())
            {
                int score = other.GetComponent<ScoreGive>().GetScore();
                sm.RpcScore(score, ownerIdentity);
            }

            Debug.Log("Hit " + other.gameObject);
        }
    }
}

//networktransform