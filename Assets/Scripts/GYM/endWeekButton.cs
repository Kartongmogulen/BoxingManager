using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endWeekButton : MonoBehaviour
{
    public activeWorkout ActiveWorkout;
    public heavyBagWorkoutStats HeavyBagWorkoutStats;
    public playerXPManager PlayerXPManager;

    public Text weekCounterText;
    public int weekCounter;

    //När veckan avslutas i gymmet

    public void updateXPforStat()
    {

        if (ActiveWorkout.knockout == true)
        {
            
            PlayerXPManager.knockdownXP += HeavyBagWorkoutStats.XPWorkout[HeavyBagWorkoutStats.lvlHeavyBag];
           
            PlayerXPManager.knockdownXPUpdate();
        }

        
        if (ActiveWorkout.bodyshot == true)
        {
            PlayerXPManager.bodyshotXP += HeavyBagWorkoutStats.XPWorkout[HeavyBagWorkoutStats.lvlHeavyBag];
            Debug.Log("UpdateXP Bodyshot");
            PlayerXPManager.bodyshotXPUpdate();
        }

        //PlayerXPManager.knockdownXPUpdate();
    }

    public void updateWeekCount()
    {
        weekCounter++;
        weekCounterText.text = "Week: " + weekCounter;
    }

}
