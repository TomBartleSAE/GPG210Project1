using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Zach
{


    public class FlashingLight : NetworkBehaviour
    {
        public Light light;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Model
            if (Random.value < 0.15f)
            {
                if (isServer)
                {
                    RpcSetColourOfLight(Random.value, Random.value, Random.value);
                }
            }
        }

        [ClientRpc]
        void RpcSetColourOfLight(float r, float g, float b)
        {
            //View
            light.color = new Color(r, g, b);
        }
    }
}
