using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jabFight : MonoBehaviour
{
    //public int succededActionsMeasure; //Antal lyckade action. Detta som avgör om specialegenskaper funkar

    bool actionCompletedOrNot;
    public bool dodgeCompletedOrNot;

    public succedOrNotAction SuccedOrNotAction;
    public dodgeCheckCompletion DodgeCheckCompletion;
    public fightStatsShared FightStatsShared;

    public GameObject fightUIScripts;

    public int i;//ENDAST FÖR FELSÖKNING
    public int singelPunchInt;//ENDAST FÖR FELSÖKNING

    private void Start()
    {
        SuccedOrNotAction = GetComponent<succedOrNotAction>();
        DodgeCheckCompletion = GetComponent<dodgeCheckCompletion>();
        //FightStatsShared = GetComponent<fightStatsShared>();
    }

    public void jabHead(player attacker, player defender, bool singelPunch)
    {


        //2.START-----------
        if (defender.dodgeActive == true)
        {
           
            dodgeCompletedOrNot = DodgeCheckCompletion.checkIfDodgeSucced(attacker.accuracy, defender.dodge);
            //Debug.Log("Stamina before: " + defender.name + " " + defender.staminaHealthNow);
            defender.staminaHealthNow -= FightStatsShared.dodgeActiveReduceStaminaBy; //Minskar stamina på försvararen
            //Debug.Log("Stamina after: " + defender.name + " " + defender.staminaHealthNow);
            Debug.Log("Dodge Completed: " + dodgeCompletedOrNot);
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
          
        //else
        //{
            actionCompletedOrNot = SuccedOrNotAction.action(attacker.accuracy, defender.guardHead, true);
        //}
        //2.END-----------

        if (actionCompletedOrNot == true)
        {
            attacker.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            defender.GetComponent<player>().updateHeadHealth(attacker.jabDamageHead);
            //9.1 END----------

            //3.START-------------------

            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, true, true, false);
        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, true, false, false);
            attacker.fightStatisticsNumberOfFailedActions();
        }
        if (attacker.Opponent == false)
        {
            fightUIScripts.GetComponent<attackHeadManager>().playerOneJab();
        }
        else
        {
            fightUIScripts.GetComponent<attackHeadManager>().playerTwoJab();
        }
        //3.END-------------------

        //4.START----------
        attacker.GetComponent<player>().updateStamina(attacker.jabStaminaUseHead);
        //4.END----------
       
        //Debug.Log("JabHead: " + i);
        //Debug.Log("Spelare TVÅ attackerar: " + attacker.Opponent +" " + i);
        //Spelare Ett är attackerande
        if (attacker.Opponent == false)
        {
            GetComponent<fightManager>().updatePlayerOne();
            //GetComponent<fightManager>().afterActionChoicePlayerOne(1);
           
            if (singelPunch == true && GetComponent<fightManager>().simulation == false)
            {

                GetComponent<fightManager>().afterActionChoicePlayerOne(1);
                singelPunchInt++;
            }

            
        }

       

        //Spelare Två är attackerande
        else
        {
            i++;
            //Debug.Log("SpelareTvåsTur innan UpdatePlayerTwo");
            GetComponent<fightManager>().updatePlayerTwo();
            //GetComponent<fightManager>().afterActionChoicePlayerTwo();
            if (singelPunch == true)
            {
                //Debug.Log("JabFight-script - Jab");
                GetComponent<fightManager>().afterActionChoicePlayerTwo(1);
            }
        }

    }

    public void measureJab(player attacker, player defender)
    {
        actionCompletedOrNot = SuccedOrNotAction.action(attacker.accuracy + attacker.measureJabIncreaseAccuracyWhenActive, defender.guardHead, true);
        
        if (actionCompletedOrNot == true)
        {
            attacker.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            defender.GetComponent<player>().updateHeadHealth(attacker.jabDamageLow);
            //9.1 END----------

            //9.1.2 START--------
            attacker.measureJabSuccededDurigFight++;

            if (attacker.measureJabSuccededDurigFight >= attacker.measureJabLimit)
                attacker.measureJabIncreaseAccuracyWhenActive = attacker.measureJabPotentialIncreaseAccuracy;
            //9.1.2 END--------

            //3.START-------------------
            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, true, true, false);
        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, true, false, false);
            attacker.fightStatisticsNumberOfFailedActions();
        }
        fightUIScripts.GetComponent<attackHeadManager>().playerOneJab();
        //3.END-------------------
        //4.START----------
        attacker.GetComponent<player>().updateStamina(attacker.jabStaminaUseLow);
        //4.END----------
        if (attacker.Opponent == false)
        {
            GetComponent<fightManager>().updatePlayerOne();
            GetComponent<fightManager>().afterActionChoicePlayerOne(1);
        }
        else
        {
            GetComponent<fightManager>().updatePlayerTwo();
            GetComponent<fightManager>().afterActionChoicePlayerTwo(1);
        }
    }

    //Vid en lyckad aktion/runda minskar motståndaren Accuracy
    public void keepDistanceJab(player attacker, player defender)
    {
        //Lyckas attacken eller inte
        actionCompletedOrNot = SuccedOrNotAction.action(attacker.accuracy + attacker.measureJabIncreaseAccuracyWhenActive, defender.guardHead, true);

        if (actionCompletedOrNot == true)
        {
            attacker.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            //Justerar hälsa
            defender.GetComponent<player>().updateHeadHealth(attacker.jabDamageLow);
            //9.1 END----------

            //9.1.2 START--------
            attacker.jabKeepDistanceActive = true;
            Debug.Log("keepdistance: " + attacker.jabKeepDistanceActive);

            //9.1.2 END--------
            fightUIScripts.GetComponent<attackHeadManager>().playerOneJab();
            //3.START-------------------
            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, true, true, false);
        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, true, true, false, false);
            attacker.fightStatisticsNumberOfFailedActions();
        }

        //3.END-------------------
        //4.START----------
        attacker.GetComponent<player>().updateStamina(attacker.jabStaminaUseHead);
        //4.END----------

        if (attacker.Opponent == false)
        {
            GetComponent<fightManager>().updatePlayerOne();
            GetComponent<fightManager>().afterActionChoicePlayerOne(1);
        }
        else
        {
            GetComponent<fightManager>().updatePlayerTwo();
            GetComponent<fightManager>().afterActionChoicePlayerTwo(1);
        }

    }

    public void jabBody(player attacker, player defender, bool singelPunch)
    {


        //2.START-----------
        if (defender.jabKeepDistanceActive == true)
        {
            actionCompletedOrNot = SuccedOrNotAction.action(attacker.accuracy - defender.jabKeepDistanceStatBoost, defender.guardBody, true);
        }
        else
        {
            actionCompletedOrNot = SuccedOrNotAction.action(attacker.accuracy, defender.guardBody, true);
        }
        //2.END-----------

        if (actionCompletedOrNot == true)
        {
            attacker.fightStatisticsNumberOfSuccededActions();
            //9.1 START----------
            defender.GetComponent<player>().updateBodyHealth(attacker.jabDamageBody);
            defender.GetComponent<player>().updateStamina(attacker.jabStaminaDamageBody);
            //9.1 END----------

            //3.START-------------------

            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, false, true, true, false);
        }
        else
        {
            fightUIScripts.GetComponent<commentatorManager>().startTimer(attacker, defender, false, true, false, false);
            attacker.fightStatisticsNumberOfFailedActions();
        }

        if (attacker.Opponent == false)
        {
            fightUIScripts.GetComponent<attackBodyManager>().playerOneJab();
        }
        else
        {
            fightUIScripts.GetComponent<attackBodyManager>().playerTwoJab();
        }

        //fightUIScripts.GetComponent<attackHeadManager>().playerOneJab();
        //3.END-------------------

        //4.START----------
        attacker.GetComponent<player>().updateStamina(attacker.jabStaminaUseBody);
        //4.END----------

        //Spelare Ett är attackerande
        if (attacker.Opponent == false)
        {
            GetComponent<fightManager>().updatePlayerOne();
         
            if (singelPunch == true && GetComponent<fightManager>().simulation == false)
            { 
                GetComponent<fightManager>().afterActionChoicePlayerOne(1);
                singelPunchInt++;
            }


        }

        //Spelare Två är attackerande
        else
        {
            i++;
            //Debug.Log("SpelareTvåsTur innan UpdatePlayerTwo");
            GetComponent<fightManager>().updatePlayerTwo();
            //GetComponent<fightManager>().afterActionChoicePlayerTwo();
            if (singelPunch == true)
            {
                //Debug.Log("JabFight-script - Jab");
                GetComponent<fightManager>().afterActionChoicePlayerTwo(1);
            }
        }

    }

}
