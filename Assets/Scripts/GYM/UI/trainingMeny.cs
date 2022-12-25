using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trainingMeny : MonoBehaviour
{
    public trainingStatManager TrainingStatManager;
    public heavyBagWorkoutStats HeavyBagWorkoutStats;

    public player PlayerOne;
    public playerXPManager PlayerXPManager;
    public activeWorkout ActiveWorkout;
    public Button buttonOne;
    public Text buttonOneText;
    public Button buttonTwo;
    public Text buttonTwoText;

    public Text playerStatLvlNow;
    public Text playerXPNow;
    public Text playerXPAfter;

    private void Start()
    {
       
    }

    public void showPossibleWorkouts(string workoutOne, string workoutTwo)
    {
        buttonOneText.text = workoutOne;
        buttonTwoText.text = workoutTwo;
    }

    public void buttonOneClick()
    {
        inactiveAll();
        if (buttonOneText.text == "Knockout")
        {
            playerStatLvlNow.text = "Knockout: " + PlayerOne.knockdownChance;
            playerXPNow.text = "XP now: " + PlayerXPManager.knockdownXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.knockdownChance];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.knockdownXP + HeavyBagWorkoutStats.XPWorkout[HeavyBagWorkoutStats.lvlHeavyBag]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.knockdownChance];
            ActiveWorkout.knockout = true;
        }
    }

    
    public void buttonTwoClick()
    {
        inactiveAll();
        if (buttonTwoText.text == "Bodyshot")
        {
            playerStatLvlNow.text = "Bodyshot: " + PlayerOne.reduceOpponentStaminaRecoveryChance;
            playerXPNow.text = "XP now: " + PlayerXPManager.bodyshotXP + "/" + TrainingStatManager.xpPerLvl[PlayerOne.reduceOpponentStaminaRecoveryChance];
            playerXPAfter.text = "XP after: " + (PlayerXPManager.bodyshotXP + HeavyBagWorkoutStats.XPWorkout[HeavyBagWorkoutStats.lvlHeavyBag]) + "/" + TrainingStatManager.xpPerLvl[PlayerOne.reduceOpponentStaminaRecoveryChance];
            ActiveWorkout.bodyshot = true;
        }
    }
    
    //Nollställer val av workout
    public void inactiveAll()
    {
        ActiveWorkout.knockout = false;
        ActiveWorkout.bodyshot = false;
    }


}
