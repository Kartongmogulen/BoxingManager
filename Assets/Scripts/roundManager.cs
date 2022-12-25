using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class roundManager : MonoBehaviour
{
    /*Hanterar
    1. Rondnummer
    2. Klocka
    */

    private int roundFightLength; //Antal ronder i fighten
    public int roundNow;
    public int minInRound; //Antal min som gått i ronden
    public float secInRound; //Antal sekunder som gått i ronden
    private float roundActionsPerPlayer; //Antal aktioner varje spelare får göra innan ronden är slut
    public bool playerOneWonOnDecision;

    public GameObject victoryPanelGO;
    public GameObject statisticsGO;
    public GameObject simPanelGO;
    public GameObject rankingsScriptsGO;

    public TextMeshProUGUI roundClock;
    public TextMeshProUGUI simPanelRoundClock;

    public int bugg_i; //FÖR BUGG
    public bool timerJumpStartOn;
    public float timeBeforeJumpStartSim; //Tid innan simulering ska försöka tvångsstartas
    public float timerJumpStart;

    private void Start()
    {
        roundFightLength = GetComponent<fightManager>().roundFightLength;
        roundActionsPerPlayer = GetComponent<fightManager>().roundActionsPerRound;
        //roundNow = 1;
    }

    private void Update()
    {
        //Kontrollerar om simulering fastnar

        if (rankingsScriptsGO.GetComponent<simRankedFight>().simulationRankedON == true)
        {
            if (timerJumpStartOn == true)
                timerJumpStart += Time.deltaTime;

            if (timerJumpStart > timeBeforeJumpStartSim)
            {
                Debug.Log("JumpStartTimerReached");
                rankingsScriptsGO.GetComponent<simRankedFight>().startSimFight();
            }

            if (timerJumpStart > timeBeforeJumpStartSim * 1.5f)
            {
                rankingsScriptsGO.GetComponent<simRankedFight>().continueSimLoop = false;
            }
        }
    }

    public void afterPlayerAction()
    {
        bugg_i++;
        //Debug.Log(bugg_i);

        secInRound += 180 / roundActionsPerPlayer / 2;
        
        if (secInRound>=60)
        {
            minInRound++;
            secInRound = secInRound - 60;
        }

        if (minInRound == 3)
        {
            resetRound();
            
            //Debug.Log("Round now: " + roundNow);
        }

        roundClock.text = "Round: " + roundNow + "  Min: " + minInRound +  " Sec: " + secInRound;
        simPanelRoundClock.text = "Round: " + roundNow + "  Min: " + minInRound + " Sec: " + secInRound;
    }

    //Nollställer vid rondens slut
   public void resetRound()
    {
        //timerJumpStart = 0;
        //timerJumpStartOn = true;
        //Debug.Log("Round now: " + roundNow);
        roundNow++;
        minInRound = 0;

        GetComponent<betweenRounds>().recoverStats(GetComponent<fightManager>().PlayerTwo);
        GetComponent<scorecardManager>().compareKnockdowns();

        //Matchen har gått tiden ut
        if (roundNow == roundFightLength)
        {
            Debug.Log("Matchen har gått tiden ut");
            playerOneWonOnDecision = GetComponent<scorecardManager>().scorecardToGetWinner();
            //if (playerOneWonOnDecision == true)
            GetComponent<fightManager>().fightEndedDecision();
            //victoryPanelGO.GetComponent<afterFightUpdate>().decisionUpdate(playerOneWonOnDecision);
        }

        //SIMULERING
        if (GetComponent<fightManager>().simulation == true )
        {
            timerJumpStart = 0;
            timerJumpStartOn = true;
            simPanelGO.GetComponent<simulateFight>().roundEnded = true; //För att kunna simulera en rond
            simPanelGO.GetComponent<simulateFight>().resetDataAfterRound();
            simPanelGO.GetComponent<simulateFight>().startFight();
        }

        if (rankingsScriptsGO.GetComponent<simRankedFight>().simulationRankedON == true)
        {
            Debug.Log("SimRankedOn, Round ended");
            rankingsScriptsGO.GetComponent<simRankedFight>().startSimFight();

            
        }
    }

    public void resetRoundAfterFight()
    {
        //Debug.Log("ResetRoundAfterFight");
        roundNow = 1;
        minInRound = 0;
        secInRound = 0;

        roundClock.text = "Round: " + roundNow + "  Min: " + minInRound + " Sec: " + secInRound;
        simPanelRoundClock.text = "Round: " + roundNow + "  Min: " + minInRound + " Sec: " + secInRound;
    }

    public void addStatisticFightEndedRound()
    {
        statisticsGO.GetComponent<fightStatistics>().addRound(roundNow);
    }
}
