using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyTimer : MonoBehaviour
{

    public float timer = 3f;
    private bool timeUp;

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if (timer < 0)
            timeUp = true;
        
        if(timeUp)
            Destroy(gameObject);
    }
}
