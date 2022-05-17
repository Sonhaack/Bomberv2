using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotatespeed;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up,rotatespeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().AddScore();
            Destroy(gameObject);
        }
    }
}
