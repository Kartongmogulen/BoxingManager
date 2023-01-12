using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endOfMonthPanelUI : MonoBehaviour
{
    public moneyManager MoneyManager;
    public Text priceMoneyText;

    public void updatePriceMoneyText(int lvlOpponent)
    {
        if (lvlOpponent == 0)
        {
            priceMoneyText.text = "Pricemoney: " + MoneyManager.priceMoneyLvlZeroVictory;
        }
        if (lvlOpponent == 1)
        {
            priceMoneyText.text = "Pricemoney: " + MoneyManager.priceMoneyLvlOneVictory;
        }

    }

}
