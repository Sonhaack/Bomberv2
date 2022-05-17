using System;
using System.Collections;
using System.Collections.Generic;
using ArionDigital;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{


    public float seconds;
    private float radius;
    public GameObject explosionEffect;
    public GameObject firetrail;
    private Player player;
    private bool hasExploded = false;
    private float currentTime;


    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        radius = player.getBombRadius();
        currentTime = seconds;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        currentTime -= 1 * Time.fixedDeltaTime;
        if (currentTime < 1 && !hasExploded)
        {
            Explode();
        }

    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        hasExploded = true;
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Instantiate(explosionEffect, pos, rot);
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("BombExplosion");
        foreach (Collider nearbyObjects in colliders)
        {
        
            if (nearbyObjects.transform.CompareTag("Player"))
            {
                nearbyObjects.transform.GetComponentInChildren<Animator>().SetBool("isDead", true);
            }

            if (nearbyObjects.transform.CompareTag("Breakable"))
            {
                nearbyObjects.transform.GetComponent<CrashCrate>().FractureCrate();
            }

            if (nearbyObjects.transform.CompareTag("Enemy"))
            {
                nearbyObjects.transform.GetComponentInChildren<Animator>().SetBool("isDead", true);
            }
        }
    }
}


     

