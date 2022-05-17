using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public GameObject text;

    public float setMinutes;
    public float setSeconds;

    private float minutesLeft;
    private float secondsLeft;

    void Start()
    {
        minutesLeft = setMinutes;
        secondsLeft = setSeconds;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (secondsLeft < 0 && minutesLeft > 0)
        {
            minutesLeft -= 1;
            secondsLeft = 59f;
        }

        if (secondsLeft <= 0 && minutesLeft <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        text.GetComponent<TextMeshProUGUI>().text = minutesLeft.ToString("00") + ":" + secondsLeft.ToString("00");
        secondsLeft -= 1 * Time.deltaTime;
        
        
        
    }
}
