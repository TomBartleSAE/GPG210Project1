using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Zach
{
    public class Threading : MonoBehaviour
    {
        public int threadCount;
        public Thread[] threads;
        
        
        // Start is called before the first frame update
        /*IEnumerator Start()
        {
            yield return new WaitForSeconds(2);

            Thread thread = new Thread(DoStuff);
            thread.Start();
        }


        public void DoStuff()
        {
            Debug.Log("Start thread");
            transform.forward = Vector3.forward; 
            Thread.Sleep(4000);
            Debug.Log("End thread");
        }*/

        
        
        
        // Start is called before the first frame update
        IEnumerator Start()
        {
            yield return new WaitForSeconds(2);

            threads = new Thread[threadCount];
            
            for (int i = 0; i < threadCount; i++)
            {
                threads[i] = new Thread(DoStuff);
                threads[i].Start();
            }
            
        }

        public void DoStuff()
        {
            Debug.Log("Start thread");
            Thread.Sleep(3000);
            Debug.Log("End thread");
        }

    }
}