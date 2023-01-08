using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playModeOn : MonoBehaviour
{
    
    //Scriptet ska vara aktiv n�r spelet ska k�ras i skarpt-l�ge

    public GameObject champChoosePanelGO;
    public GameObject fightScriptsGO;
    public GameObject playerPanelScriptGO;
    public GameObject gymPanelGO;
    public GameObject endOfWeekPanelGO;
    public GameObject jabHeadMeasureGO;
    public GameObject jabKeepDistanceGO;
    public GameObject fightStatModifierPanelGO;

    public player PlayerOne;

    [Header("Ranking Manager")]
    public int victoriesToUnlockChamps; //Antal segrar innan Spelaren kan m�ta Champions
    //public int playerRankedLvlForBelt; //N�r spelaren �r Rankad och sl�s f�r b�ltet
    //public int limitToRankUpPlayer; //Antal fler segrar �n f�rluster.

    [Header("Matchinst�llning")]
    public int roundFightLength;
    public int actionsPerRound; //Antal aktioner innan det blir n�sta spelarens tur
    public int totalKOBeforeFightEnds;



    private void Awake()
    {
        //UI vid start
        gymPanelGO.SetActive(true);
        endOfWeekPanelGO.SetActive(false);

        //UI FightPanel
        fightStatModifierPanelGO.SetActive(false);
        jabHeadMeasureGO.SetActive(false);
        jabKeepDistanceGO.SetActive(false);

        //R�tt GO Player v�ljs
        fightScriptsGO.GetComponent<fightManager>().PlayerOne = PlayerOne;
        playerPanelScriptGO.GetComponent<playerStatsUIController>().setUpPlayerGO();
        playerPanelScriptGO.GetComponent<playerStatsUIController>().updateText();

        //Ranking
        GetComponentInParent<rankingManager>().playerRanked = false;
        GetComponentInParent<rankingManager>().victoriesToUnlockChamps = victoriesToUnlockChamps;
        //champChoosePanelGO.SetActive(false);
        //GetComponentInParent<rankingManager>().playerRankedLvlForBelt = playerRankedLvlForBelt;
        //GetComponentInParent<rankingManager>().limitToRankUpPlayer = limitToRankUpPlayer;

        //Match-inst�llningar
        fightScriptsGO.GetComponent<fightManager>().roundFightLength = roundFightLength;
        fightScriptsGO.GetComponent<fightManager>().roundActionsPerRound = actionsPerRound;
        fightScriptsGO.GetComponent<fightManager>().totalKnockdownCountBeforeStop = totalKOBeforeFightEnds;
        
        //Player One. Nollst�l till grundinst�llningar
        PlayerOne.oneTwoUnlocked = false;
        
    }

 

}
