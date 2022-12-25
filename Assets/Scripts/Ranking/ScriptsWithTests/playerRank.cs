using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRank : MonoBehaviour
{

    public static int checkPlayerRank(int limitToRankUpPlayer, int playerRankedLvl, int pointsNowPlayer)
    {
        if (limitToRankUpPlayer * playerRankedLvl + limitToRankUpPlayer <= pointsNowPlayer)
        {
            playerRankedLvl++;
            Debug.Log("Rank up!");
        }

        return playerRankedLvl;
    }
}
