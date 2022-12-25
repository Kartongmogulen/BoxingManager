using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossFight : MonoBehaviour
{
    bool actionCompletedOrNot;
    public bool dodgeCompletedOrNot;
    public bool knockdownState;

    public succedOrNotAction SuccedOrNotAction;
    public dodgeCheckCompletion DodgeCheckCompletion;
    public fightStatsShared FightStatsShared;

    knockdown Knockdown;
    public GameObject fightUIScripts;

    private void Start()
    {
        SuccedOrNotAction = GetComponent<succedOrNotAction>();
        DodgeCheckCompletion = GetComponent<dodgeCheckCompletion>();
        Knockdown = GetComponent<knockdown>();
    }

    public void crossHead(player attacker, player defender, bool singelPunch, int accuracyBoost)
    {
        //Debug.Log("CrossHead");
        //2.START-----------
        if (defender.dodgeActive == true)
        {

            dodgeCompletedOrNot = DodgeCheckCompletion.checkIfDodgeSucced(attacker.accuracy, defender.dodge);
            //Debug.Log("DodgeCompletedOrNot: " + dodgeCompletedOrNot);

            defender.staminaHealthNow -= FightStatsShared.dodgeActiveReduceStaminaBy;

            if (dodgeCompletedOrNot == true)
            {
                GetComponent<dodgeCompleted>().whatActionAfterSuccededDodge();
                defender.dodgeCompleted++;
            }
        }

        else if (defender.jabKeepDistanceActive == true)
        {
            actionCompletedOrNot = SuccedOrNotAction.action(attacker.accuracy - defender.jabKeepDistanceStatBoost, defender.guardHead, true);
        }

        else
        {
            actionCompletedOrNot = SuccedOrNotAction.action(attacker.accuracy, defender.guardHead, true);
        }
        //2.END-----------

        //Träffar slaget
        if (actionCompletedOrNot == true)
        {
            attacker.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            defender.GetComponent<player>().updateHeadHealth(attacker.crossDamageHead);
            //9.1 END----------

            //9.1.2 START----------
            knockdownState = Knockdown.willPlayerGetKnockdown(attacker, defender, true);
            if (knockdownState == true)
            {
                //Debug.Log("PlayerTwo KO");
                defender.fighterStateUpdate(true);
                fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, false, true, true);
                defender.GetComponent<fightStatsKnockdownCause>().specialAttackCrossKO();
            }
            //9.1.2 END----------
            
        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, false, false, false);
            attacker.fightStatisticsNumberOfFailedActions();
        }
        //3.END-------------------

        //Debug.Log("Opponent: " + attacker.Opponent);
        if (attacker.Opponent == false)
        {
            fightUIScripts.GetComponent<attackHeadManager>().playerOneCross();
        }
        else
        {
            fightUIScripts.GetComponent<attackHeadManager>().playerTwoCross();
        }
        //3.START-------------------
        if (knockdownState == false)
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, false, true, false);
        }

        //fightUIScripts.GetComponent<attackHeadManager>().playerOneCross();
        //4.START----------
        attacker.GetComponent<player>().updateStamina(attacker.crossStaminaUseHead);
        //4.END----------

        if (attacker.Opponent == false)
        {
            GetComponent<fightManager>().updatePlayerOne();

            if (singelPunch == true && GetComponent<fightManager>().simulation == false)
            {

                GetComponent<fightManager>().afterActionChoicePlayerOne(1);

            }
        }

        else
        {

            GetComponent<fightManager>().updatePlayerTwo();
 
            if (singelPunch == true)
            {
                GetComponent<fightManager>().afterActionChoicePlayerTwo(1);
            }
        }

    }
}

