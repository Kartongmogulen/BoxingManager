using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class equipmentLevelManager : MonoBehaviour
{
    public List<int> equipmentLvlCost; //Kostnad för att uppgradering

    public int lvlHeavyBag;
    public int lvlFoamsticks;

    //Aktivt redskap
    public bool heavybagActive;
    public bool foamsticksActive;

    //Maxlevel nådd
    public bool heavybagMaxLevel;

    public Text costText;
    public Text increasedWorkoutXPText;
    public Text specialWorkoutText; //Det som är unikt nämns här

    public Button lvlUpButton;

    public GameObject heavybagColliderGO;

    public workoutStats WorkoutStats;

    public void chooseHeavybag()
    {
        heavybagActive = true;
        costText.text = " Cost: " + equipmentLvlCost[lvlHeavyBag];
        
        //Kontrollerar om Maxnivå är nådd
        if (lvlHeavyBag == WorkoutStats.XPWorkout.Count-1)
        {
            increasedWorkoutXPText.text = " MAX LEVEL";
            heavybagMaxLevel = true;

            if (heavybagMaxLevel == true)
            {
                maxLevelReached();
            }
        }
        else
            increasedWorkoutXPText.text = " Increased XP per workout: " + WorkoutStats.XPWorkout[lvlHeavyBag + 1];

        if (lvlHeavyBag == 0)
        {
            specialWorkoutText.text = " Unlock OneTwo-Combo";
        }

    }

    public void heavybagLvlUp()
    {
        heavybagColliderGO.GetComponent<gymEquipmentOnClick>().workoutThreeStat = "OneTwoCombo";
        specialWorkoutText.text = "";
    }

    public void chooseFoamsticks()
    {
        foamsticksActive = true;
        costText.text = " Cost: " + equipmentLvlCost[lvlFoamsticks];
        increasedWorkoutXPText.text = " Increased XP per workout: " + WorkoutStats.XPWorkout[lvlFoamsticks + 1];
        //specialWorkoutText.text = " Unlock OneTwo-Combo";
    }

    public void maxLevelReached()
    {
        lvlUpButton.interactable = false;
    }

}
