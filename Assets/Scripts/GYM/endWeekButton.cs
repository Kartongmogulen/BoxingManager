using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endWeekButton : MonoBehaviour
{
    public activeWorkout ActiveWorkout;
    public workoutStats WorkoutStats;
    public playerXPManager PlayerXPManager;
    public equipmentLevelManager EquipmentLevelManager;

    public Text weekCounterText;
    public int weekCounter;

    //När veckan avslutas i gymmet

    public void updateXPforStat()
    {

        if (ActiveWorkout.accuracy == true)
        {
            PlayerXPManager.accuracyXP += WorkoutStats.XPWorkout[WorkoutStats.lvlTennisball];
            Debug.Log("UpdateXP Accuracy");
            PlayerXPManager.accuracyXPUpdate();
        }

        if (ActiveWorkout.bodyshot == true)
        {
            PlayerXPManager.bodyshotXP += WorkoutStats.XPWorkout[EquipmentLevelManager.lvlHeavyBag];
            Debug.Log("UpdateXP Bodyshot");
            PlayerXPManager.bodyshotXPUpdate();
        }

        if (ActiveWorkout.bodyHealth == true)
        {
            PlayerXPManager.bodyHealthXP += WorkoutStats.XPWorkout[WorkoutStats.lvlSafetyMattress];
            Debug.Log("UpdateXP BodyHealth");
            PlayerXPManager.bodyHealthXPUpdate();
        }

        if (ActiveWorkout.dodge == true)
        {
            PlayerXPManager.dodgeXP += WorkoutStats.XPWorkout[WorkoutStats.lvlTennisball];
            Debug.Log("UpdateXP Dodge");
            PlayerXPManager.dodgeXPUpdate();
        }

        if (ActiveWorkout.headHealth == true)
        {
            PlayerXPManager.headHealthXP += WorkoutStats.XPWorkout[WorkoutStats.lvlSafetyMattress];
            Debug.Log("UpdateXP HeadHealth");
            PlayerXPManager.headHealthXPUpdate();
        }

        if (ActiveWorkout.guardBody == true)
        {
            PlayerXPManager.guardBodyXP += WorkoutStats.XPWorkout[EquipmentLevelManager.lvlFoamsticks];
            Debug.Log("UpdateXP guardBody");
            PlayerXPManager.guardBodyXPUpdate();
        }

        if (ActiveWorkout.guardFlex == true)
        {
            PlayerXPManager.guardFlexXP += WorkoutStats.XPWorkout[EquipmentLevelManager.lvlFoamsticks];
            Debug.Log("UpdateXP guardFlex");
            PlayerXPManager.guardFlexXPUpdate();
        }

        if (ActiveWorkout.guardHead == true)
        {
            PlayerXPManager.guardHeadXP += WorkoutStats.XPWorkout[EquipmentLevelManager.lvlFoamsticks];
            Debug.Log("UpdateXP guardHead");
            PlayerXPManager.guardHeadXPUpdate();
        }

        if (ActiveWorkout.knockout == true)
        {
            
            PlayerXPManager.knockdownXP += WorkoutStats.XPWorkout[EquipmentLevelManager.lvlHeavyBag];
           
            PlayerXPManager.knockdownXPUpdate();
        }

        if (ActiveWorkout.staminaMax == true)
        {

            PlayerXPManager.staminaMaxXP += WorkoutStats.XPWorkout[WorkoutStats.lvlOutside];

            PlayerXPManager.staminaMaxXPUpdate();
        }


        if (ActiveWorkout.staminaRecovery == true)
        {

            PlayerXPManager.staminaRecXP += WorkoutStats.XPWorkout[WorkoutStats.lvlOutside];

            PlayerXPManager.staminaRecoveryXPUpdate();
        }

        if (ActiveWorkout.strength == true)
        {

            PlayerXPManager.strengthXP += WorkoutStats.XPWorkout[WorkoutStats.lvlSafetyMattress];

            PlayerXPManager.strengthXPUpdate();
        }

        if (ActiveWorkout.oneTwoCombo == true)
        {

            PlayerXPManager.comboOneTwoXP += WorkoutStats.XPWorkout[EquipmentLevelManager.lvlHeavyBag];

            PlayerXPManager.comboOneTwoXPUpdate();
        }


        //PlayerXPManager.knockdownXPUpdate();
    }

    public void updateWeekCount()
    {
        weekCounter++;
        weekCounterText.text = "Week: " + weekCounter;
    }

}
