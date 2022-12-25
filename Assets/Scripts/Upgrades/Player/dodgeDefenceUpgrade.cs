using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgeDefenceUpgrade : MonoBehaviour
{
    public player playerOne;

    public void add()
    {
        if (playerOne.expPointsNow > 0)
        {
            playerOne.dodge++;
            playerOne.expPointsNow--;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }

    public void sub()
    {
        if (playerOne.dodge > 0 && playerOne.dodge > playerOne.dodgeAfterLastFight)
        {
            playerOne.dodge--;
            playerOne.expPointsNow++;
            GetComponent<playerStatsUIController>().updateText();
        }
        else
            return;
    }
}
