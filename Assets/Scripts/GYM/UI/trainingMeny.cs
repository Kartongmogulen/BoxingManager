using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trainingMeny : MonoBehaviour
{
    public trainingStatManager TrainingStatManager;
    public workoutStats WorkoutStats;
    public equipmentLevelManager EquipmentLevelManager;
    public attributeManager AttributeManager;

    public player PlayerOne;
    public playerXPManager PlayerXPManager;
    public activeWorkout ActiveWorkout;
    
    public Button buttonOne;
    public bool buttonOneActive;
    public Text buttonOneText;
    public Text buttonOneTextTwo;
    public Button buttonTwo;
    public bool buttonTwoActive;
    public Text buttonTwoText;
    public Text buttonTwoStatTwoText;
    public GameObject buttonThreeGO;
    public bool buttonThreeActive;
    public Text buttonThreeText;
    public Text buttonThreeStatTwoText;

    //Stat 1
    public Text playerStatLvlNow;
    public Text playerXPNow;
    public Text playerXPAfter;

    //Stat 2
    public Text playerStatTwoLvlNow;
    public Text playerXPNowStatTwo;
    public Text playerXPAfterStatTwo;

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

    public void showCombinedWorkoutStat(string workoutOne)
    {
        buttonOneTextTwo.text = workoutOne;
        buttonTwoStatTwoText.text = workoutOne;
        buttonThreeStatTwoText.text = workoutOne;

    }

    public void buttonOneClick()
    {
        inactiveAll();
        inactiveButtons();
        buttonOneActive = true;

        if (buttonOneText.text == "Accuracy")
        {
            playerStatLvlNow.text = "Accuracy: " + PlayerOne.accuracy;
            playerXPNow.text = "XP now: " + PlayerXPManager.accuracyXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.accuracy-PlayerOne.accuarcyStartOfGame];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.accuracyXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlTennisball]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.accuracy-PlayerOne.accuarcyStartOfGame];
            ActiveWorkout.accuracy = true;
        }

        else if (buttonOneText.text == "Knockout")
        {
            playerStatLvlNow.text = "Knockout: " + PlayerOne.knockdownChance;
            playerXPNow.text = "XP now: " + PlayerXPManager.knockdownXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.knockdownChance];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.knockdownXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlHeavyBag]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.knockdownChance];
            ActiveWorkout.knockout = true;
        }

        else if (buttonOneText.text == "Strength")
        {
            playerStatLvlNow.text = "Strength: " + PlayerOne.strength;
            playerXPNow.text = "XP now: " + PlayerXPManager.strengthXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.strength-PlayerOne.strengthStartOfGame];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.strengthXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlSafetyMattress]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.strength-PlayerOne.strengthStartOfGame];
            ActiveWorkout.strength = true;
        }

        else if (buttonOneText.text == "GuardHead")
        {
            Debug.Log("ButtonOneClick GuardHead");
            playerStatLvlNow.text = "GuardHead: " + PlayerOne.guardHead;
            playerXPNow.text = "XP now: " + PlayerXPManager.guardHeadXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.guardHead-1]; //Justerar då guard startar på 1
            playerXPAfter.text = "XP after: " + (PlayerXPManager.guardHeadXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlFoamsticks]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.guardHead-1];
            ActiveWorkout.guardHead = true;
        }

        else if (buttonOneText.text == "StaminaMax")
        {
            Debug.Log("ButtonOneClick StaminaMax");
            playerStatLvlNow.text = "StaminaMax: " + PlayerOne.staminaHealthNow;
            playerXPNow.text = "XP now: " + PlayerXPManager.staminaMaxXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.playerLvlHealthStamina];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.staminaMaxXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlOutside]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.playerLvlHealthStamina];
            ActiveWorkout.staminaMax = true;
        }

        if(buttonOneTextTwo.text == "Accuracy" && EquipmentLevelManager.foamsticksActive == true)
        {
         
            playerStatTwoLvlNow.text = "Accuracy: " + PlayerOne.accuracy;
            playerXPNowStatTwo.text = "XP now: " + PlayerXPManager.accuracyXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.accuracy - PlayerOne.accuarcyStartOfGame];
            playerXPAfterStatTwo.text = "XP after: " + (PlayerXPManager.accuracyXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlFoamsticks-1]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.accuracy - PlayerOne.accuarcyStartOfGame];
            ActiveWorkout.accuracy = true;
        }
       
    }

    
    public void buttonTwoClick()
    {
        inactiveAll();
        inactiveButtons();
        buttonTwoActive = true;
        if (buttonTwoText.text == "Bodyshot")
        {
            playerStatLvlNow.text = "Bodyshot: " + PlayerOne.reduceOpponentStaminaRecoveryChance;
            playerXPNow.text = "XP now: " + PlayerXPManager.bodyshotXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.reduceOpponentStaminaRecoveryChance];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.bodyshotXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlHeavyBag]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.reduceOpponentStaminaRecoveryChance];
            ActiveWorkout.bodyshot = true;
        }

        if (buttonTwoText.text == "Dodge")
        {
            playerStatLvlNow.text = "Dodge: " + PlayerOne.dodge;
            playerXPNow.text = "XP now: " + PlayerXPManager.dodgeXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.dodge];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.dodgeXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlTennisball]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.dodge];
            ActiveWorkout.dodge = true;
        }

        if (buttonTwoText.text == "HealthHead")
        {
            playerStatLvlNow.text = "HealthHead: " + PlayerOne.headHealthNow;
            playerXPNow.text = "XP now: " + PlayerXPManager.headHealthXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.playerLvlHealthHead];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.headHealthXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlSafetyMattress]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.playerLvlHealthHead];
            ActiveWorkout.headHealth = true;
        }

        if (buttonTwoText.text == "GuardBody")
        {
            //Debug.Log("ButtonOneClick GuardBody");
            playerStatLvlNow.text = "GuardBody: " + PlayerOne.guardBody;
            playerXPNow.text = "XP now: " + PlayerXPManager.guardBodyXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.guardBody - 1]; //Justerar då guard startar på 1
            playerXPAfter.text = "XP after: " + (PlayerXPManager.guardBodyXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlFoamsticks]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.guardBody - 1];
            ActiveWorkout.guardBody = true;
        }

        if (buttonTwoText.text == "StaminaRecovery")
        {
            //Debug.Log("ButtonOneClick GuardBody");
            playerStatLvlNow.text = "StaminaRecovery: " + PlayerOne.staminaRecoveryBetweenRounds;
            playerXPNow.text = "XP now: " + PlayerXPManager.staminaRecXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.playerLvlHealthStaminaRecovery]; 
            playerXPAfter.text = "XP after: " + (PlayerXPManager.staminaRecXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlOutside]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.playerLvlHealthStaminaRecovery];
            ActiveWorkout.staminaRecovery = true;
        }

        if (buttonTwoStatTwoText.text == "Accuracy" && EquipmentLevelManager.foamsticksActive == true)
        {

            playerStatTwoLvlNow.text = "Accuracy: " + PlayerOne.accuracy;
            playerXPNowStatTwo.text = "XP now: " + PlayerXPManager.accuracyXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.accuracy - PlayerOne.accuarcyStartOfGame];
            playerXPAfterStatTwo.text = "XP after: " + (PlayerXPManager.accuracyXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlFoamsticks - 1]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.accuracy - PlayerOne.accuarcyStartOfGame];
            ActiveWorkout.accuracy = true;
        }
    }

    public void buttonThreeClick()
    {
        inactiveAll();
        inactiveButtons();
        buttonThreeActive = true;
        if (buttonThreeText.text == "HealthBody")
        {
            playerStatLvlNow.text = "HealthBody: " + PlayerOne.bodyHealthNow;
            playerXPNow.text = "XP now: " + PlayerXPManager.bodyHealthXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.playerLvlHealthBody];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.bodyHealthXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlSafetyMattress]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.playerLvlHealthBody];
            ActiveWorkout.bodyHealth = true;
        }

        if (buttonThreeText.text == "GuardFlex")
        {
            playerStatLvlNow.text = "GuardFlex: " + PlayerOne.guardFlexibleDuringFight;
            playerXPNow.text = "XP now: " + PlayerXPManager.guardFlexXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.guardFlexibleDuringFight];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.guardFlexXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlFoamsticks]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.guardFlexibleDuringFight];
            ActiveWorkout.guardFlex = true;
        }

        if (buttonThreeText.text == "OneTwoCombo")
        {
            if (PlayerOne.oneTwoUnlocked == false)
            {
                playerStatLvlNow.text = "OneTwoCombo: NOT LEARNED";
                playerXPNow.text = "XP now: " + PlayerXPManager.comboOneTwoXP + "/" + AttributeManager.oneTwoCostUnlock;
                playerXPAfter.text = "XP after: " + (PlayerXPManager.comboOneTwoXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlHeavyBag]) + "/" + AttributeManager.oneTwoCostUnlock;
            }

            if (PlayerOne.oneTwoUnlocked == true && PlayerOne.oneTwoComboLvl == AttributeManager.oneTwoCostToLvlUp.Count)
            {
                playerStatLvlNow.text = "OneTwoCombo: lvl: " + PlayerOne.oneTwoComboLvl;
                playerXPNow.text = "XP now: MAX level";// + PlayerXPManager.comboOneTwoXP + "/" + AttributeManager.oneTwoCostToLvlUp[PlayerOne.oneTwoComboLvl];
                playerXPAfter.text = "XP after: MAX level";// + (PlayerXPManager.comboOneTwoXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlHeavyBag]) + "/" + AttributeManager.oneTwoCostToLvlUp[PlayerOne.oneTwoComboLvl];

            }

            else if (PlayerOne.oneTwoUnlocked == true && PlayerOne.oneTwoComboLvl < AttributeManager.oneTwoCostToLvlUp.Count)
            {
                playerStatLvlNow.text = "OneTwoCombo: lvl: " + PlayerOne.oneTwoComboLvl;
                playerXPNow.text = "XP now: " + PlayerXPManager.comboOneTwoXP + "/" + AttributeManager.oneTwoCostToLvlUp[PlayerOne.oneTwoComboLvl];
                playerXPAfter.text = "XP after: " + (PlayerXPManager.comboOneTwoXP + WorkoutStats.XPWorkout[EquipmentLevelManager.lvlHeavyBag]) + "/" + AttributeManager.oneTwoCostToLvlUp[PlayerOne.oneTwoComboLvl];

            }
            ActiveWorkout.oneTwoCombo = true;

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
        ActiveWorkout.staminaMax = false;
        ActiveWorkout.staminaRecovery = false;

        ActiveWorkout.oneTwoCombo = false;

    }

    public void inactiveButtons()
    {
        buttonOneActive = false;
        buttonTwoActive = false;
        buttonThreeActive = false;
    }

    public void updateGymUI()
    {
        if (buttonOneActive == true)
        {
            buttonOneClick();
        }

        if (buttonTwoActive == true)
        {
            buttonTwoClick();
        }

        if (buttonThreeActive == true)
        {
            buttonThreeClick();
        }
    }


}
