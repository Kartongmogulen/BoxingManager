using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentAI : MonoBehaviour
{
    //Styr motståndarens beteende

    public fightManager FightManager;
    public defendHeadManager DefendHeadManager;
    public defendBodyManager DefendBodyManager;
    public player Opponent;
    public int guardAreaExtraLimit; //Gräns då motståndaren börjar skydda ett område mer

    private void Start()
    {
        FightManager = GetComponent<fightManager>();
        DefendHeadManager = GetComponentInChildren<defendHeadManager>();
        DefendBodyManager = GetComponentInChildren<defendBodyManager>();
    }

    public void getOpponentStart()
    {
        Opponent = FightManager.PlayerTwo;
       
    }

    //Kontrollerar om gräns för att skydda sig extra aktiveras
    public void defenceGuardPoints(player Opponent)
    {
        //Kontrollera om något område är under gränsen för extra guard

            //Debug.Log("Gräns Skydd: " + guardAreaExtraLimit * Opponent.headHealthStart / 100);

        if (Opponent.headHealthNow <= guardAreaExtraLimit * Opponent.headHealthStart / 100 && Opponent.bodyHealthNow <= guardAreaExtraLimit * Opponent.bodyHealthStart / 100)
        {
            Debug.Log("Båda delarna lika utsatta");

            Opponent.guardFlexibleBodyActive = false;
            Opponent.guardFlexibleHeadActive = false;

            //Opponent.guardBody = Opponent.guardBodyStatAfterLastFight;
            //Opponent.guardHead = Opponent.guardHeadStatAfterLastFight;
            //Opponent.guardUpdate();
            //Visualisera skydd
            DefendHeadManager.playerTwoExtraGuardHeadInactive();
            DefendBodyManager.playerTwoExtraGuardBodyInactive();
        }

        else if (Opponent.headHealthNow <= guardAreaExtraLimit * Opponent.headHealthStart/100)
        {
            Opponent.guardFlexibleHeadActive = true;
            Opponent.guardFlexibleBodyActive = false;
            //Opponent.guardUpdate();
            Debug.Log("Guard Head, Opponent AI: " + Opponent.guardHead);

            //Visualisera skydd
            DefendHeadManager.playerTwoExtraGuardHeadActive();
            DefendBodyManager.playerTwoExtraGuardBodyInactive();
        }

        else if (Opponent.bodyHealthNow<= guardAreaExtraLimit * Opponent.bodyHealthStart / 100)
        {
            //Debug.Log("Motstånd Namn: " + Opponent.name);
            //Debug.Log("Skydda Kropp");
            Opponent.guardFlexibleBodyActive = true;
            Opponent.guardFlexibleHeadActive = false;
            //Opponent.guardUpdate();

           
            //Mindre skydd Huvud

            //Visualisera skydd
            DefendBodyManager.playerTwoExtraGuardActive();
            DefendHeadManager.playerTwoExtraGuardHeadInactive();
        }

        Opponent.guardUpdate();

    }
}
