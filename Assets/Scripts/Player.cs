using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    
    private Rigidbody rb;
    private Animator animator;
    public float speed = 10f;
    public float countDown = 3;
    private int Coins;
    private int maxCoins;
    private int sceneIndex;
    public float bombRadius = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);
        setMaxCoins(sceneIndex);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Disable movements when dead
        if (!animator.GetBool("isDead"))
        {
            // Controls
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

            
            // Animations
            if (movement == Vector3.zero)
            {
                animator.SetBool("isRunning", false);
                return;
            }
            animator.SetBool("isRunning", true);
            
            
            // rotation
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            //movement
            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
            rb.MoveRotation(targetRotation);
            
            // restart if player fall off the map
            if (transform.position.y < -10)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
        // if dead
        else
        {
            countDown += -1 * Time.deltaTime;
            Debug.Log(countDown);

            if (countDown < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                countDown = 3;
            }
        }
    }

    public void AddScore()
    {
        Coins += 1;
    }

    public int getCoins()
    {
        return Coins;
    }

    public int getMaxCoins()
    {
        return maxCoins;
    }

    private void setMaxCoins(int sceneIndex)
    {
        if (sceneIndex == 1)
            maxCoins = 10;
        if (sceneIndex == 2)
            maxCoins = 15;
    }

    public bool enoughCoins()
    {
        return Coins >= maxCoins;
    }

    public float getBombRadius()
    {
        return bombRadius;
    }

    public void addBombRadius()
    {
        bombRadius += 1;
    }
}
