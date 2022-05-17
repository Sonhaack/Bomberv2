using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeCoin : MonoBehaviour
{
    public float rotatespeed;
    // Start is called before the first frame update
    
    void Update()
    {
        transform.Rotate(Vector3.up,rotatespeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           other.GetComponent<Player>().addBombRadius();
            Debug.Log("Range added");
            Destroy(gameObject);
        }
    }
    
}
