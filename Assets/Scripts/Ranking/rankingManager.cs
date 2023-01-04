using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rankingManager : MonoBehaviour
{
    //Hanterar Ranking systemet

    public int lvlBeforeBecomingRanked; //Antal niv�er Spelaren m�ter "Orankat" motst�nd.

    public int playerRankedLvl; //Vilken niv� spelaren �r p�. Orankad B�rjar p� 0.
    public int playerRankedLvlForBelt; //N�r spelaren �r Rankad och sl�s f�r b�ltet
    public int limitToRankUpPlayer; //Antal fler segrar �n f�rluster.

    public int rankedForFirstTime;

    public int victoriesToUnlockChamps; //X antal segrar innan spelaren l�ser upp Champions;

    //public createOpponentAttributeList CreateOpponentAttributeListSO;
    public GameObject playerListChampionsFixed;
    public bool playerRanked;

    public bool lostAgainstChamp; //Om spelaren f�rlorar mot Champ ska X antal matcher vinnas mot s�mre motstand innan ny chans.
    public int victoriesAfterLossChampBeforeNewChance;
    public int victoriesAfterLossChamp;

    public GameObject playerPanelUIGO;
    public GameObject fightScriptsGO;
    public GameObject championsPanelGO;
    public GameObject championsButtonGO;
    
    //public willPlayerRankUp WillPlayerRankUp;

    //START ENDAST F�R TEST
    /*public void Start()
    {
        checkIfPlayerWillRankUp(0);
    
    }*/

    public void unlockChampionsAfterXFights(int victories)
    {
        if (victories >= victoriesToUnlockChamps)
        {
            playerRanked = true;
        }

        if (playerRanked == true)
        {
            championsButtonGO.SetActive(true);
        }
    }

    public void checkIfPlayerWillRankUp(int victories)
    {
        //Debug.Log("Kontrollera om spelaren rankar upp script");
        //Debug.Log("Rank gr�ns: " + (limitToRankUpPlayer * playerRankedLvl + limitToRankUpPlayer));
        if (limitToRankUpPlayer * playerRankedLvl + limitToRankUpPlayer <= victories)
        {
            playerRankedLvl++;
            //Debug.Log("Rank up!");
        }

        //Debug.Log("L�ngd: " + CreateOpponentAttributeListSO.accuracyAndStrengthPointsToShare.Length);
        
        //Blir Spelaren Rankad.
        if (playerRankedLvl >= lvlBeforeBecomingRanked)
        {
            //Debug.Log("Spelaren �r nu RANKAD");
            playerRanked = true;

        }

        if (playerRanked == true)
        {
            rankedForFirstTime++;
            //playerPanelUIGO.GetComponent<playerIsRankedUI>().playerCanOnlyChooseOneOpponent();
            championsPanelGO.SetActive(true);
        }

        if (playerRanked == true && lostAgainstChamp == true)
        {
            championsPanelGO.SetActive(false);
        }
        
        if (playerRanked == true && rankedForFirstTime == 1)
        {
            fightScriptsGO.GetComponent<fightManager>().PlayerTwo = playerListChampionsFixed.GetComponent<playerList>().PlayerList[0];
            //Debug.Log("Ranked First Time");
        }

        //chanceAgainstChampion();
    }

    public void resultAgainstChamp(bool Victory)
    {
        //Debug.Log("ResultAgainstChamp: " + Victory);
        if (Victory == false)
        {
            //championsPanelGO.SetActive(false);
            lostAgainstChamp = true;
            //Debug.Log("F�rlust mot Champion");
        }

        if (Victory == true)
        {
            //Debug.Log("Seger mot Champion");
            victoriesAfterLossChamp++;
        }

        if (victoriesAfterLossChamp == victoriesAfterLossChampBeforeNewChance)
        {
            lostAgainstChamp = false;
            //Debug.Log("Ny chans mot Champion");
            victoriesAfterLossChamp = 0;
            championsPanelGO.SetActive(true);
        }
    }
}
