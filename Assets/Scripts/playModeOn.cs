using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playModeOn : MonoBehaviour
{
    
    //Scriptet ska vara aktiv när spelet ska köras i skarpt-läge

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
    public int victoriesToUnlockChamps; //Antal segrar innan Spelaren kan möta Champions
    //public int playerRankedLvlForBelt; //När spelaren är Rankad och slås för bältet
    //public int limitToRankUpPlayer; //Antal fler segrar än förluster.

    [Header("Matchinställning")]
    public int roundFightLength;
    public int actionsPerRound; //Antal aktioner innan det blir nästa spelarens tur
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

        //Rätt GO Player väljs
        fightScriptsGO.GetComponent<fightManager>().PlayerOne = PlayerOne;
        playerPanelScriptGO.GetComponent<playerStatsUIController>().setUpPlayerGO();
        playerPanelScriptGO.GetComponent<playerStatsUIController>().updateText();

        //Ranking
        GetComponentInParent<rankingManager>().playerRanked = false;
        GetComponentInParent<rankingManager>().victoriesToUnlockChamps = victoriesToUnlockChamps;
        //champChoosePanelGO.SetActive(false);
        //GetComponentInParent<rankingManager>().playerRankedLvlForBelt = playerRankedLvlForBelt;
        //GetComponentInParent<rankingManager>().limitToRankUpPlayer = limitToRankUpPlayer;

        //Match-inställningar
        fightScriptsGO.GetComponent<fightManager>().roundFightLength = roundFightLength;
        fightScriptsGO.GetComponent<fightManager>().roundActionsPerRound = actionsPerRound;
        fightScriptsGO.GetComponent<fightManager>().totalKnockdownCountBeforeStop = totalKOBeforeFightEnds;
        
        //Player One. Nollstäl till grundinställningar
        PlayerOne.oneTwoUnlocked = false;
        
    }

 

}
