using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    
    public TextMeshProUGUI text;
    
    private Player player;
    private string showCoins;
    private int coins;
    private int maxCoins;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        coins = player.getCoins();
        maxCoins = player.getMaxCoins();
        showCoins = "Coins: " + coins + "/" + maxCoins;
        text.GetComponent<TextMeshProUGUI>().text = showCoins;
    }
}
