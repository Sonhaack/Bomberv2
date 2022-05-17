using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bombs : MonoBehaviour
{

    public GameObject text;
    public SpawnBomb script;
    private string bombsAmount;
    void Start()
    {
        script = GameObject.FindWithTag("Player").GetComponent<SpawnBomb>();
    }

    // Update is called once per frame
    void Update()
    {
        bombsAmount = "Bombs: " + script.bombs;
        text.GetComponent<TextMeshProUGUI>().text = bombsAmount;
    }
}
