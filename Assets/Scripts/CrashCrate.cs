using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

    public class CrashCrate : MonoBehaviour
    {
        public MeshRenderer wholeCrate;
        public BoxCollider boxCollider;
        public GameObject fracturedCrate;
        public float time = 3f;
        public GameObject coin;
        public GameObject enemy;
        public GameObject rangeCoin;
        private float randomNumber;
        
        public void FractureCrate()
        {
            wholeCrate.enabled = false;
            boxCollider.enabled = false;
            fracturedCrate.SetActive(true);
            randomNumber = Random.Range(0f, 10f);
            if (randomNumber > 5 && randomNumber < 9)
            {
                Instantiate(coin, transform.position, transform.rotation);
            }

            if (randomNumber > 9)
            {
                Instantiate(enemy, transform.position, transform.rotation);
            }
            
            if (randomNumber > 0 && randomNumber < 1)
            {
                Instantiate(rangeCoin, transform.position, transform.rotation);
            }
            
            Invoke("DestroySelf", time);
        }
        private void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
