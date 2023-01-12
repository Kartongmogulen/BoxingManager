using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class afterFightUpdate : MonoBehaviour
{
    public Text fighterWhoWonText;
    public Text VictoryByText;
    public Text XPAwardText;
    public GameObject playerPanelGO;
    public GameObject nextButton;
    public GameObject xpAwardGO;
    public GameObject gameloopScriptsGO;


    public void updateTextChampion(player PlayerOne)
    {
        fighterWhoWonText.text = PlayerOne.name + " is now the CHAMPION!";
        VictoryByText.text = "Weeks to become champion: " + gameloopScriptsGO.GetComponent<endWeekButton>().weekCounter;
        XPAwardText.text = "With a record of W:" + PlayerOne.GetComponent<boxRecord>().victory + " L:" + PlayerOne.GetComponent<boxRecord>().defeat;
        nextButton.SetActive(false); //D� spelet bara hade en Champ och spelet var slut vid f�rsta b�ltet
        xpAwardGO.SetActive(true);
    }

   public void updateText(player PlayerOne, bool playerOneWon)
    {
        if (playerOneWon == true)
        {
            fighterWhoWonText.text = PlayerOne.name + " won!";
            VictoryByText.text = "Victory by: KO";
            XPAwardText.text = "XP awarded: " + playerPanelGO.GetComponent<fightAwardList>().awardListExperience[0];
            PlayerOne.expPointsNow += playerPanelGO.GetComponent<fightAwardList>().awardListExperience[0];

        }

        else if (playerOneWon == false)
        {
            fighterWhoWonText.text = PlayerOne.name + " lost!";
            VictoryByText.text = "Lost by: KO";
            XPAwardText.text = "XP awarded: " + playerPanelGO.GetComponent<fightAwardList>().awardListExperience[3];
            PlayerOne.expPointsNow += playerPanelGO.GetComponent<fightAwardList>().awardListExperience[3];
        }

    }

    public void decisionUpdate(bool playerOneWonOnDecision)
    {
        if (playerOneWonOnDecision == true)
        {
            fighterWhoWonText.text = "Victory!";
            VictoryByText.text = "Victory by: Decision";
            XPAwardText.text = "XP awarded: " + playerPanelGO.GetComponent<fightAwardList>().awardListExperience[1];
            playerPanelGO.GetComponent<playerStatsUIController>().Player.expPointsNow += playerPanelGO.GetComponent<fightAwardList>().awardListExperience[1];
        }

        else

        {
            fighterWhoWonText.text = "Lost!";
            VictoryByText.text = "Lost by: Decision";
            XPAwardText.text = "XP awarded: " + playerPanelGO.GetComponent<fightAwardList>().awardListExperience[2];
            playerPanelGO.GetComponent<playerStatsUIController>().Player.expPointsNow += playerPanelGO.GetComponent<fightAwardList>().awardListExperience[2];
        }
    }
}
