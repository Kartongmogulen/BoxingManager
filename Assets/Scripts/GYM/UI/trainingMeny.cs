using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trainingMeny : MonoBehaviour
{
    public trainingStatManager TrainingStatManager;
    public workoutStats WorkoutStats;

    public player PlayerOne;
    public playerXPManager PlayerXPManager;
    public activeWorkout ActiveWorkout;
    public Button buttonOne;
    public Text buttonOneText;
    public Button buttonTwo;
    public Text buttonTwoText;
    public GameObject buttonThreeGO;
    public Text buttonThreeText;

    public Text playerStatLvlNow;
    public Text playerXPNow;
    public Text playerXPAfter;

    private void Start()
    {
       
    }

    public void showPossibleWorkouts(string workoutOne, string workoutTwo, string workoutThree)
    {
        buttonOneText.text = workoutOne;
        buttonTwoText.text = workoutTwo;
        if (workoutThree == "")
        {
            buttonThreeGO.SetActive(false);
        }
        else
        {
            buttonThreeGO.SetActive(true);
            buttonThreeText.text = workoutThree;
        }
    }

    public void buttonOneClick()
    {
        Debug.Log("ButtonOneClick Start");
        inactiveAll();
        Debug.Log("ButtonOneClick 1");
        if (buttonOneText.text == "Accuracy")
        {
            Debug.Log("ButtonOneClick 2");
            playerStatLvlNow.text = "Accuracy: " + PlayerOne.accuracy;
            Debug.Log("ButtonOneClick 3");
            playerXPNow.text = "XP now: " + PlayerXPManager.accuracyXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.accuracy-PlayerOne.accuarcyStartOfGame];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.accuracyXP + WorkoutStats.XPWorkout[WorkoutStats.lvlTennisball]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.accuracy-PlayerOne.accuarcyStartOfGame];
            ActiveWorkout.accuracy = true;
        }

        else if (buttonOneText.text == "Knockout")
        {
            playerStatLvlNow.text = "Knockout: " + PlayerOne.knockdownChance;
            playerXPNow.text = "XP now: " + PlayerXPManager.knockdownXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.knockdownChance];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.knockdownXP + WorkoutStats.XPWorkout[WorkoutStats.lvlHeavyBag]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.knockdownChance];
            ActiveWorkout.knockout = true;
        }

        else if (buttonOneText.text == "Strength")
        {
            playerStatLvlNow.text = "Strength: " + PlayerOne.strength;
            playerXPNow.text = "XP now: " + PlayerXPManager.strengthXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.strength-PlayerOne.strengthStartOfGame];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.strengthXP + WorkoutStats.XPWorkout[WorkoutStats.lvlSafetyMattress]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.strength-PlayerOne.strengthStartOfGame];
            ActiveWorkout.strength = true;
        }

        else if (buttonOneText.text == "GuardHead")
        {
            Debug.Log("ButtonOneClick GuardHead");
            playerStatLvlNow.text = "GuardHead: " + PlayerOne.guardHead;
            playerXPNow.text = "XP now: " + PlayerXPManager.guardHeadXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.guardHead-1]; //Justerar då guard startar på 1
            playerXPAfter.text = "XP after: " + (PlayerXPManager.guardHeadXP + WorkoutStats.XPWorkout[WorkoutStats.lvlFoamsticks]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.guardHead-1];
            ActiveWorkout.guardHead = true;
        }

        
    }

    
    public void buttonTwoClick()
    {
        inactiveAll();
        if (buttonTwoText.text == "Bodyshot")
        {
            playerStatLvlNow.text = "Bodyshot: " + PlayerOne.reduceOpponentStaminaRecoveryChance;
            playerXPNow.text = "XP now: " + PlayerXPManager.bodyshotXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.reduceOpponentStaminaRecoveryChance];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.bodyshotXP + WorkoutStats.XPWorkout[WorkoutStats.lvlHeavyBag]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.reduceOpponentStaminaRecoveryChance];
            ActiveWorkout.bodyshot = true;
        }

        if (buttonTwoText.text == "Dodge")
        {
            playerStatLvlNow.text = "Dodge: " + PlayerOne.dodge;
            playerXPNow.text = "XP now: " + PlayerXPManager.dodgeXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.dodge];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.dodgeXP + WorkoutStats.XPWorkout[WorkoutStats.lvlTennisball]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.dodge];
            ActiveWorkout.dodge = true;
        }

        if (buttonTwoText.text == "HealthHead")
        {
            playerStatLvlNow.text = "HealthHead: " + PlayerOne.headHealthNow;
            playerXPNow.text = "XP now: " + PlayerXPManager.headHealthXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.playerLvlHealthHead];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.headHealthXP + WorkoutStats.XPWorkout[WorkoutStats.lvlSafetyMattress]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.playerLvlHealthHead];
            ActiveWorkout.headHealth = true;
        }

        if (buttonTwoText.text == "GuardBody")
        {
            Debug.Log("ButtonOneClick GuardBody");
            playerStatLvlNow.text = "GuardBody: " + PlayerOne.guardBody;
            playerXPNow.text = "XP now: " + PlayerXPManager.guardBodyXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.guardBody - 1]; //Justerar då guard startar på 1
            playerXPAfter.text = "XP after: " + (PlayerXPManager.guardBodyXP + WorkoutStats.XPWorkout[WorkoutStats.lvlFoamsticks]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.guardBody - 1];
            ActiveWorkout.guardBody = true;
        }
    }

    public void buttonThreeClick()
    {
        inactiveAll();

        if (buttonThreeText.text == "HealthBody")
        {
            playerStatLvlNow.text = "HealthBody: " + PlayerOne.bodyHealthNow;
            playerXPNow.text = "XP now: " + PlayerXPManager.bodyHealthXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.playerLvlHealthBody];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.bodyHealthXP + WorkoutStats.XPWorkout[WorkoutStats.lvlSafetyMattress]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.playerLvlHealthBody];
            ActiveWorkout.bodyHealth = true;
        }

        if (buttonThreeText.text == "GuardFlex")
        {
            playerStatLvlNow.text = "GuardFlex: " + PlayerOne.guardFlexibleDuringFight;
            playerXPNow.text = "XP now: " + PlayerXPManager.guardFlexXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.guardFlexibleDuringFight];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.guardFlexXP + WorkoutStats.XPWorkout[WorkoutStats.lvlFoamsticks]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.guardFlexibleDuringFight];
            ActiveWorkout.guardFlex = true;
        }

    }

        //Nollställer val av workout
        public void inactiveAll()
    {
        ActiveWorkout.accuracy = false;
        ActiveWorkout.bodyshot = false;
        ActiveWorkout.bodyHealth = false;
        ActiveWorkout.dodge = false;
        ActiveWorkout.headHealth = false;
        ActiveWorkout.guardBody = false;
        ActiveWorkout.guardFlex = false;
        ActiveWorkout.guardHead = false;
        ActiveWorkout.knockout = false;
        ActiveWorkout.strength = false;

    }


}
