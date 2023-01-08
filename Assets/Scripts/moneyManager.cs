using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyManager : MonoBehaviour
{
    public int moneyStart;
    public int moneyNow;

    //Segerpengar
    public int priceMoneyLvlZeroVictory;

    public Text moneyNowText;

    private void Start()
    {
        moneyNow = moneyStart;
        moneyNowText.text = "Money: " + moneyNow;
    }

    public void decreaseMoney(int moneyConsumed)
    {
        moneyNow -= moneyConsumed;
        moneyNowText.text = "Money: " + moneyNow;
    }

    public void increaseMoney(int money)
    {
        moneyNow += money;
        moneyNowText.text = "Money: " + moneyNow;
    }

    public void priceMoneyLvlZeroVictoryFunc()
    {
        moneyNow += priceMoneyLvlZeroVictory;
        moneyNowText.text = "Money: " + moneyNow;
    }
}
