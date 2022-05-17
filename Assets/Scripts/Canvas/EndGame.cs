using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    
    public float timer = 2f;
    // Update is called once per frame
    void Update()
    {
        Debug.Log(timer);
        timer -= 1 * Time.deltaTime;
        if (timer < 0)
        {
            Debug.Log("Change scene");
            SceneManager.LoadScene("Menu");
        }
    }
}
