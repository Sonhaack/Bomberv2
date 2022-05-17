using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    
    public Rigidbody bomb;
    public float spawnDistance = 1f;
    public Vector3 offset;
    public int bombs;
    public int maxBombs;
    public float reloadTime = 3f;
    public float reloadTimeLeft = 0f;
    
    void Update()
    {
        //Spawn bomb
        if (Input.GetButtonDown("Fire1") && bombs > 0)
        {
            bombs += -1;
            Vector3 playerPos = transform.position;
            Vector3 playerDirection = transform.forward;
            Quaternion playerRotation = transform.rotation;
            Vector3 spawnPos = playerPos + offset + playerDirection * spawnDistance;
            Instantiate(bomb, spawnPos, playerRotation);
        }
        
        //Reload
        if (reloadTimeLeft <= reloadTime && maxBombs > bombs)
            reloadTimeLeft -= 1 * Time.deltaTime;
        if (reloadTimeLeft < 0)
        {
            if (bombs < maxBombs)
            {
                bombs += 1;    
            }
            reloadTimeLeft = reloadTime;
        }
    }
}
