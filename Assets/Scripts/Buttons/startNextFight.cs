using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startNextFight : MonoBehaviour
{
    /// <summary>
    /// Hanterar att starta n?sta Fight
    /// </summary>

    public GameObject fightScriptGO;
    public GameObject FightUiGO;
    public player playerOne;
    public player playerTwo;

    public healthPanelTextUpdate HealthPanelTextUpdate;
    public playerStatsUIController PlayerStatsUIController;

    public GameObject playerPanelGO;
    public GameObject playerPanelScriptsGO;
    public GameObject fightPanelGO;
    public GameObject victoryPanelGO;
    public GameObject endOfMonthPanelGO;
    public GameObject gymPanelGO;
    public GameObject moneyTextGO;
    public GameObject playerStatsButtonGO;

    private void Start()
    {
        HealthPanelTextUpdate = FightUiGO.GetComponent<healthPanelTextUpdate>();
        playerOne = fightScriptGO.GetComponent<fightManager>().PlayerOne;
        //saveStatsForPlayer();
    }

    public void playerPanelToFight()
    {
        playerPanelGO.SetActive(false);
        fightPanelGO.SetActive(true);
        GetComponent<dodgeOnOffButton>().startFight();
        fightScriptGO.GetComponent<fightManager>().setUpFight();
        HealthPanelTextUpdate.updatePlayerOneText();
        playerOne.startFight();
        saveStatsForPlayer();
        saveStatsForOpponent();
    }

    public void endOfMonthPanelToFight()
    {
        endOfMonthPanelGO.SetActive(false);
        fightPanelGO.SetActive(true);
        moneyTextGO.SetActive(false);
        playerStatsButtonGO.SetActive(false);
        GetComponent<dodgeOnOffButton>().startFight();
        fightScriptGO.GetComponent<fightManager>().setUpFight();
        HealthPanelTextUpdate.updatePlayerOneText();
        playerOne.startFight();
        PlayerStatsUIController.guardDuringFight();

        saveStatsForPlayer();
        saveStatsForOpponent();
    }

    //Sparar stats f?r spelaren s? det ej g?r att f? l?gre vid n?sta match ?n dessa po?ng.
    //Ska inte g? att g? ner i lvl.
    public void saveStatsForPlayer()
    {
        playerOne.accuracyStatAfterLastFight = playerOne.accuracy;
        playerOne.strengthStatAfterLastFight = playerOne.strength;
        playerOne.knockdownChanceStatAfterLastFight = playerOne.knockdownChance;
        playerOne.reduceOpponentStaminaRecoveryChanceStatAfterLastFight = playerOne.reduceOpponentStaminaRecoveryChance;
        playerOne.guardHeadStatAfterLastFight = playerOne.guardHead;
        playerOne.guardBodyStatAfterLastFight = playerOne.guardBody;
        playerOne.guardFlexibleDuringFightAfterLastFight = playerOne.guardFlexibleDuringFight;
        playerOne.headHealthAfterLastFight = playerOne.headHealthStart;
        playerOne.bodyHealthStatAfterLastFight = playerOne.bodyHealthStart;
        playerOne.staminaHealthAfterLastFight = playerOne.playerLvlHealthStamina;
        playerOne.staminaRecoveryBetweenRoundsAfterLastFight = playerOne.staminaRecoveryBetweenRounds;
    }

    public void saveStatsForOpponent()
    {
        playerTwo = fightScriptGO.GetComponent<fightManager>().PlayerTwo;

        playerTwo.guardHeadStatAfterLastFight = playerTwo.guardHead;
        playerTwo.guardBodyStatAfterLastFight = playerTwo.guardBody;

        playerTwo.knockdownChanceStatAfterLastFight = playerTwo.knockdownChance;
        playerTwo.reduceOpponentStaminaRecoveryChanceStatAfterLastFight = playerTwo.reduceOpponentStaminaRecoveryChance;
    }

    public void victoryPanelToGymPanel()
    {
        victoryPanelGO.SetActive(false);
        gymPanelGO.SetActive(true);
        moneyTextGO.SetActive(true);
        playerStatsButtonGO.SetActive(true);

        playerPanelScriptsGO.GetComponent<playerStatsUIController>().updateText();
    }

        public void victoryPanelToPlayerPanel()
    {
        victoryPanelGO.SetActive(false);
        playerPanelGO.SetActive(true);
        playerPanelScriptsGO.GetComponent<playerStatsUIController>().updateText();
    }


}
