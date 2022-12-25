using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simRankedFight : MonoBehaviour
{
    public playerList PlayerList;

    public player PlayerOne;
    public player PlayerTwo;

    public fightManager FightManager;
    public GameObject fightScriptsGO;

    public bool fightEnded;
    public float waitSecInt;
    public int randomNumb;

    public bool continueSimLoop;
    public bool simulationRankedON;

    // Start is called before the first frame update
    void Start()
    {
        FightManager = fightScriptsGO.GetComponent<fightManager>();
    }

    public void startSimFight()
    {
     
       simulationRankedON = true;
        continueSimLoop = true;

        if (continueSimLoop == true)
            StartCoroutine(waitSec());
        //chooseAttackPlayerOne();
        //FightManager.simRankedFight();
    }
    public void setUpFight()
    {
        //Hämtar Champ och #1 contender
        PlayerOne = GetComponent<playerList>().PlayerList[0];
        PlayerTwo = GetComponent<playerList>().PlayerList[1];

        //Nollställer data inför fight
        FightManager.playerOnesTurn = true;
        FightManager.endOfFight = false;
        fightScriptsGO.GetComponent<roundManager>().resetRoundAfterFight();
        FightManager.GetComponent<scorecardManager>().resetAfterFight();
        PlayerOne.startFight();
        PlayerTwo.startFight();

        FightManager.PlayerOne = PlayerOne;
        FightManager.PlayerTwo = PlayerTwo;

    }

    public void simOneAction()
    {
        if (FightManager.playerOnesTurn == true && fightEnded == false)
        {
            chooseAttackPlayerOne();
        }

        else
        {
            Debug.Log("Player Twos Turn");
        }
    }

    public void chooseAttackPlayerOne()
    {

        if (PlayerOne.GetComponent<player>().AttackFocus == attackFocus.Head)
        {
            headHunterPlayerOne();
        }
    }

    IEnumerator waitSec()
    {

        if (fightEnded == false)
        {
            for (int i = 0; i < FightManager.roundActionsPerRound + 1; i++)
            {
                yield return new WaitForSeconds(waitSecInt);
                //simHalfRound();
                simOneAction();
                //Debug.Log("Round Ended: " + roundEnded);

                if (PlayerTwo.fighterStateNow == fighterState.Knockdown)
                {
                    FightManager.startCheckIfNextRoundCanStart();
                    yield return new WaitForSeconds(waitSecInt);
                }


            }
        }

    }

    public void headHunterPlayerOne()
    {
        //Debug.Log("Headhunter action");
        //randomNumb = 50;
        randomNumb = Random.Range(0, 100);
        //Debug.Log("Random nr: " + randomNumb);

        if (randomNumb <= 33)
        {
            FightManager.playerOneJabHead(true);
            //UIScriptsGO.GetComponent<playerTwoActionDisplay>().updateText(i, "Jab Head");
            Debug.Log("Player One: Jab Head");
        }

        else if (randomNumb <= 66)
        {
            FightManager.playerOneCrossHead(0);
            Debug.Log("Player One: Cross Head");
        }

        else if (randomNumb <= 83)
        {
            FightManager.playerOneCrossBody(0);
            Debug.Log("Player One: Cross Body");
        }

        else
        {
            FightManager.playerOneJabBody(true);
            Debug.Log("Player One: Jab Body");
        }

        fightScriptsGO.GetComponent<actionsLeftPlayer>().subActionPoints(1);
    }

    public void endOfFightPlayerOneWonByKO()
    {
        Debug.Log("Player One Won by KO");
        changeRankedPosition(0, 2);
    }

    public void endOfFightPlayerOneWonByDecision()
    {
        Debug.Log("Player One Won by Decision");
        changeRankedPosition(0, 2);
    }

    public void endOfFightPlayerTwoWonByKO()
    {
        Debug.Log("Player Two Won by KO");
        changeRankedPosition(2, 0);
    }

    public void endOfFightPlayerTwoWonByDecision()
    {
        Debug.Log("Player Two Won by Decision");
        changeRankedPosition(2, 0);
    }

    public void changeRankedPosition(int playerOneRankedAfter, int playerTwoRankedAfter)
    {
        GetComponent<playerList>().PlayerList[playerOneRankedAfter] = PlayerOne;
        GetComponent<playerList>().PlayerList[playerTwoRankedAfter] = PlayerTwo;

        //Uppdaterar UI av rankninglista
        //GetComponent<rankingListVisualisation>().updateRanking();
    }

   
}
