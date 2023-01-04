using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opponentStatsDisplayPanel : MonoBehaviour
{
    //Visar info om motståndaren i meny

    public GameObject fightScriptsGO;
    public GameObject playerListRandomGO;
    public GameObject opponentListRankedGO;
    public GameObject opponentChoosePanelGO;
    //public GameObject playerListFixedGO;
    public player Opponent;

    public Text nameOpponentText;
    public Text fightStyleText;
    public Text accuracyText;
    public Text StrengthText;
    public Text knockDownText;
    public Text BodySnatcherText;
    public Text guardHeadText;
    public Text guardBodyText;
    public Text HealthHeadText;
    public Text HealthBodyText;
    public Text staminaHealthMaxText;
    public Text staminaRecoveryHealthText;

    /*
    private void Start()
    {
        Opponent = fightScriptsGO.GetComponent<fightManager>().opponentListRandomGO.PlayerList[fightScriptsGO.GetComponent<fightManager>().opponentIndex];
        nameOpponentText.text = "Name: " + Opponent.name;
        fightStyleText.text = "Fightstyle: " + Opponent.fightStyleNow;
        accuracyText.text = "Accuracy: " + Opponent.accuracy;
        StrengthText.text = "Strength: " + Opponent.strength;
        knockDownText.text = "Knockdown: " + Opponent.knockdownChance;
        BodySnatcherText.text = "Bodysnatcher: " + Opponent.crossStaminaRecoveryDamageBody;
        guardHeadText.text = "Guard (Head): " + Opponent.guardHead;
        guardBodyText.text = "Guard (Body): " + Opponent.guardBody;
        HealthHeadText.text = "Health (Head): " + Opponent.headHealthStart;
        HealthBodyText.text = "Health (Body): " + Opponent.bodyHealthStart;
        staminaHealthMaxText.text = "Stamina, Max: " + Opponent.staminaHealthStart;
        staminaRecoveryHealthText.text = "Stamina, Recovery: " + Opponent.staminaRecoveryBetweenRounds;
    }
    */

    public void updateOpponent()
    {
        Opponent = fightScriptsGO.GetComponent<fightManager>().opponentListGO.PlayerList[fightScriptsGO.GetComponent<fightManager>().opponentIndex];
        opponentChoosePanelGO.transform.GetChild(0).GetComponent<Text>().text = "Name: " + Opponent.name;
        //nameOpponentText.text = "Name: " + Opponent.name;
        fightStyleText.text = "Fightstyle: " + Opponent.fightStyleNow;
        accuracyText.text = "Accuracy: " + Opponent.accuracy;
        StrengthText.text = "Strength: " + Opponent.strength;
        knockDownText.text = "Knockdown: " + Opponent.knockdownChance;
        BodySnatcherText.text = "Bodysnatcher: " + Opponent.crossStaminaRecoveryDamageBody;
        guardHeadText.text = "Guard (Head): " + Opponent.guardHead;
        guardBodyText.text = "Guard (Body): " + Opponent.guardBody;
        HealthHeadText.text = "Health (Head): " + Opponent.headHealthStart;
        HealthBodyText.text = "Health (Body): " + Opponent.bodyHealthStart;
        staminaHealthMaxText.text = "Stamina, Max: " + Opponent.staminaHealthStart;
        staminaRecoveryHealthText.text = "Stamina, Recovery: " + Opponent.staminaRecoveryBetweenRounds;
    }

    public void updateOpponentRandom(int index)
    {
        Opponent = fightScriptsGO.GetComponent<fightManager>().opponentListRandomGO.PlayerList[index].GetComponent<player>();
        //Opponent = playerListRandomGO.GetComponent<playerList>().PlayerList[index].GetComponent<player>();
        opponentChoosePanelGO.transform.GetChild(0).GetComponent<Text>().text = "Name: " + Opponent.name;
        //nameOpponentText.text = "Name: " + Opponent.name;
        opponentChoosePanelGO.transform.GetChild(1).GetComponent<Text>().text = "Fightstyle: " + Opponent.fightStyleNow;
        //fightStyleText.text = "Fightstyle: " + Opponent.fightStyleNow;
        opponentChoosePanelGO.transform.GetChild(2).GetComponent<Text>().text = "Accuracy: " + Opponent.accuracy;
        //accuracyText.text = "Accuracy: " + Opponent.accuracy;
        opponentChoosePanelGO.transform.GetChild(3).GetComponent<Text>().text = "Strength: " + Opponent.strength;
        //StrengthText.text = "Strength: " + Opponent.strength;
        opponentChoosePanelGO.transform.GetChild(4).GetComponent<Text>().text = "Knockdown: " + Opponent.knockdownChance;
        //knockDownText.text = "Knockdown: " + Opponent.knockdownChance;
        opponentChoosePanelGO.transform.GetChild(5).GetComponent<Text>().text = "Bodysnatcher: " + Opponent.crossStaminaRecoveryDamageBody;
        //BodySnatcherText.text = "Bodysnatcher: " + Opponent.crossStaminaRecoveryDamageBody;
        opponentChoosePanelGO.transform.GetChild(6).GetComponent<Text>().text = "Guard (Head): " + Opponent.guardHead;
        //guardHeadText.text = "Guard (Head): " + Opponent.guardHead;
        opponentChoosePanelGO.transform.GetChild(7).GetComponent<Text>().text = "Guard (Body): " + Opponent.guardBody;
        //guardBodyText.text = "Guard (Body): " + Opponent.guardBody;
        opponentChoosePanelGO.transform.GetChild(8).GetComponent<Text>().text = "Health (Head): " + Opponent.headHealthStart;
        //HealthHeadText.text = "Health (Head): " + Opponent.headHealthStart;
        opponentChoosePanelGO.transform.GetChild(9).GetComponent<Text>().text = "Health (Body): " + Opponent.bodyHealthStart;
        //HealthBodyText.text = "Health (Body): " + Opponent.bodyHealthStart;
        opponentChoosePanelGO.transform.GetChild(10).GetComponent<Text>().text = "Stamina, Max: " + Opponent.staminaHealthStart;
        //staminaHealthMaxText.text = "Stamina, Max: " + Opponent.staminaHealthStart;
        opponentChoosePanelGO.transform.GetChild(11).GetComponent<Text>().text = "Stamina, Recovery: " + Opponent.staminaRecoveryBetweenRounds;
        //staminaRecoveryHealthText.text = "Stamina, Recovery: " + Opponent.staminaRecoveryBetweenRounds;
    }

    public void updateOpponentFixed(int index)
    {
        Opponent = fightScriptsGO.GetComponent<fightManager>().opponentListRankedGO.GetComponent<playerList>().PlayerList[index].GetComponent<player>();
        nameOpponentText.text = "Name: " + Opponent.name;
        fightStyleText.text = "Fightstyle: " + Opponent.fightStyleNow;
        accuracyText.text = "Accuracy: " + Opponent.accuracy;
        StrengthText.text = "Strength: " + Opponent.strength;
        knockDownText.text = "Knockdown: " + Opponent.knockdownChance;
        BodySnatcherText.text = "Bodysnatcher: " + Opponent.crossStaminaRecoveryDamageBody;
        guardHeadText.text = "Guard (Head): " + Opponent.guardHead;
        guardBodyText.text = "Guard (Body): " + Opponent.guardBody;
        HealthHeadText.text = "Health (Head): " + Opponent.headHealthStart;
        HealthBodyText.text = "Health (Body): " + Opponent.bodyHealthStart;
        staminaHealthMaxText.text = "Stamina, Max: " + Opponent.staminaHealthStart;
        staminaRecoveryHealthText.text = "Stamina, Recovery: " + Opponent.staminaRecoveryBetweenRounds;
    }

    public void updateChampion(int index)
    {
        Opponent = opponentListRankedGO.GetComponent<playerList>().PlayerList[index].GetComponent<player>();
        nameOpponentText.text = "Name: " + Opponent.name;
        fightStyleText.text = "Fightstyle: " + Opponent.fightStyleNow;
        accuracyText.text = "Accuracy: " + Opponent.accuracy;
        StrengthText.text = "Strength: " + Opponent.strength;
        knockDownText.text = "Knockdown: " + Opponent.knockdownChance;
        BodySnatcherText.text = "Bodysnatcher: " + Opponent.crossStaminaRecoveryDamageBody;
        guardHeadText.text = "Guard (Head): " + Opponent.guardHead;
        guardBodyText.text = "Guard (Body): " + Opponent.guardBody;
        HealthHeadText.text = "Health (Head): " + Opponent.headHealthStart;
        HealthBodyText.text = "Health (Body): " + Opponent.bodyHealthStart;
        staminaHealthMaxText.text = "Stamina, Max: " + Opponent.staminaHealthStart;
        staminaRecoveryHealthText.text = "Stamina, Recovery: " + Opponent.staminaRecoveryBetweenRounds;
    }
}
