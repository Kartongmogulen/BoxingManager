using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rankingListVisualisation : MonoBehaviour
{
    public Text champNameText;
    public Text nrOneNameText;
    public Text nrTwoNameText;

    public GameObject PlayerOne;
    public GameObject gameloopScriptsGO;
    public Text victoriesLeftBeforeUnlockChampionsText;

    public void updateTextVictoriesLeftBeforeUnlockChampions()
    {
        victoriesLeftBeforeUnlockChampionsText.text = (gameloopScriptsGO.GetComponent<rankingManager>().victoriesToUnlockChamps - PlayerOne.GetComponent<boxRecord>().victoryLvlOneOpp) + " :Victories left against Lvl 1 opponents before unlocking champions";
    }


    //public playerList PlayerList;

    // Start is called before the first frame update
    /*void Start()
     {
         //PlayerList = GetComponent<playerList>();

         //updateRanking();
         /*champNameText.text = PlayerList.PlayerList[0].name;
         nrOneNameText.text = PlayerList.PlayerList[1].name;
         nrTwoNameText.text = PlayerList.PlayerList[2].name;

     }*/

    /*public void updateRanking()
    {
        champNameText.text = PlayerList.PlayerList[0].name;
        nrOneNameText.text = PlayerList.PlayerList[1].name;
        nrTwoNameText.text = PlayerList.PlayerList[2].name;
    }*/

}
