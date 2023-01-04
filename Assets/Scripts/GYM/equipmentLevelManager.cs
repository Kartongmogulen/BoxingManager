using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class equipmentLevelManager : MonoBehaviour
{
    public List<int> equipmentLvlCost; //Kostnad för att uppgradering

    public int lvlHeavyBag;
    public int lvlFoamsticks;
    public int lvlTennisball;
    public int lvlSafetyMattress;
    public int lvlOutside;

    //Aktivt redskap
    public bool heavybagActive;
    public bool foamsticksActive;
    public bool tennisballActive;
    public bool safetyMattressActive;
    public bool outsideActive;

    //Maxlevel nådd
    public bool heavybagMaxLevel;
    public bool foamsticksMaxLevel;
    public bool tennisballMaxLevel;
    public bool safetyMattressMaxLevel;
    public bool outsideMaxLevel;

    public Text costText;
    public Text increasedWorkoutXPText;
    public Text specialWorkoutText; //Det som är unikt nämns här

    public GameObject buttonOneStatTwoTextGO;
    public GameObject buttonTwoStatTwoTextGO;

    public Button lvlUpButton;

    public GameObject heavybagColliderGO;
    public GameObject foamsticksColliderGO;
    public GameObject tennisballColliderGO;
    public GameObject statTwoPanelGO;

    public workoutStats WorkoutStats;

    public void chooseHeavybag()
    {
        inactiveAllEquipment();
        inactiveTextStatTwo();
        lvlUpButton.interactable = true;
        heavybagActive = true;
        costText.text = " Cost: " + equipmentLvlCost[lvlHeavyBag];
        inactiveStatTwoPanel();

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
        inactiveAllEquipment();
        inactiveTextStatTwo();
        inactiveStatTwoPanel();
        lvlUpButton.interactable = true;
        foamsticksActive = true;
        costText.text = " Cost: " + equipmentLvlCost[lvlFoamsticks];
        //Kontrollerar om Maxnivå är nådd
        if (lvlFoamsticks == WorkoutStats.XPWorkout.Count - 1)
        {
            increasedWorkoutXPText.text = " MAX LEVEL";
            foamsticksMaxLevel = true;
            Debug.Log("2");
            if (foamsticksMaxLevel == true)
            {
                maxLevelReached();
                Debug.Log("3");
            }
        }

        if (lvlFoamsticks < WorkoutStats.XPWorkout.Count-1)
        {
            Debug.Log("4");
            increasedWorkoutXPText.text = " Increased XP per workout: " + WorkoutStats.XPWorkout[lvlFoamsticks + 1];
            Debug.Log("5");
        }

        if (lvlFoamsticks == 0)
        {
            specialWorkoutText.text = " Also train Accuracy with reduced XP";
        }

        if (lvlFoamsticks >= 1)
        {
            statTwoPanelGO.SetActive(true);
            buttonOneStatTwoTextGO.SetActive(true);
            buttonTwoStatTwoTextGO.SetActive(true);

            foamsticksColliderGO.GetComponent<gymEquipmentOnClick>().combinedWorkouts = true;
        }
    }

    public void foamsticksLvlUp()
    {
        foamsticksColliderGO.GetComponent<gymEquipmentOnClick>().workoutOneStat = "GuardHead";
        specialWorkoutText.text = "";
    }

    public void chooseTennisball()
    {
        inactiveAllEquipment();
        inactiveTextStatTwo();
        inactiveStatTwoPanel();
        lvlUpButton.interactable = true;
        tennisballActive = true;
        costText.text = " Cost: " + equipmentLvlCost[lvlTennisball];

        if (lvlTennisball == WorkoutStats.XPWorkout.Count - 1)
        {
            increasedWorkoutXPText.text = " MAX LEVEL";
            tennisballMaxLevel = true;
            //Debug.Log("2");
            if (tennisballMaxLevel == true)
            {
                maxLevelReached();
                //Debug.Log("3");
            }
        }

        if (lvlTennisball < WorkoutStats.XPWorkout.Count-1)
        {
            increasedWorkoutXPText.text = " Increased XP per workout: " + WorkoutStats.XPWorkout[lvlTennisball + 1];
        }

        specialWorkoutText.text = "";
    }

    public void chooseSafetyMattress()
    {
        inactiveAllEquipment();
        inactiveTextStatTwo();
        inactiveStatTwoPanel();
        lvlUpButton.interactable = true;
        safetyMattressActive = true;
        costText.text = " Cost: " + equipmentLvlCost[lvlSafetyMattress];

        if (lvlSafetyMattress == WorkoutStats.XPWorkout.Count - 1)
        {
            increasedWorkoutXPText.text = " MAX LEVEL";
            safetyMattressMaxLevel = true;
            //Debug.Log("2");
            if (safetyMattressMaxLevel == true)
            {
                maxLevelReached();
                //Debug.Log("3");
            }
        }

        if (lvlSafetyMattress < WorkoutStats.XPWorkout.Count - 1)
        {
            increasedWorkoutXPText.text = " Increased XP per workout: " + WorkoutStats.XPWorkout[lvlSafetyMattress + 1];
        }

        specialWorkoutText.text = "";
    }

    public void chooseOutside()
    {
        inactiveAllEquipment();
        inactiveTextStatTwo();
        inactiveStatTwoPanel();
        lvlUpButton.interactable = true;
        outsideActive = true;
        costText.text = " Cost: " + equipmentLvlCost[lvlOutside];

        if (lvlOutside == WorkoutStats.XPWorkout.Count - 1)
        {
            increasedWorkoutXPText.text = " MAX LEVEL";
            outsideMaxLevel = true;
            //Debug.Log("2");
            if (outsideMaxLevel == true)
            {
                maxLevelReached();
                //Debug.Log("3");
            }
        }

        if (lvlOutside < WorkoutStats.XPWorkout.Count - 1)
        {
            increasedWorkoutXPText.text = " Increased XP per workout: " + WorkoutStats.XPWorkout[lvlOutside + 1];
        }

        specialWorkoutText.text = "";
    }

    public void maxLevelReached()
    {
        lvlUpButton.interactable = false;
    }

    public void inactiveStatTwoPanel()
    {
        statTwoPanelGO.SetActive(false);
    }

    public void inactiveAllEquipment()
    {
        heavybagActive = false;
        foamsticksActive = false;
        tennisballActive = false;
        safetyMattressActive = false;
        outsideActive = false;
    }

    public void inactiveTextStatTwo()
    {
        buttonOneStatTwoTextGO.SetActive(false);
        buttonTwoStatTwoTextGO.SetActive(false);
    }

    public void updateTextAfterUpgrade()
    {

        if (heavybagActive == true)
        {
            heavybagColliderGO.GetComponent<gymEquipmentOnClick>().OnMouseDown();
            chooseHeavybag();
        }

        if (foamsticksActive == true)
        {
            foamsticksColliderGO.GetComponent<gymEquipmentOnClick>().OnMouseDown();
            chooseFoamsticks();
            
        }

        if (tennisballActive == true)
        {
            tennisballColliderGO.GetComponent<gymEquipmentOnClick>().OnMouseDown();
            chooseTennisball();
        }

        if (safetyMattressActive == true)
        {
            chooseSafetyMattress();
        }

        if (outsideActive == true)
        {
            chooseOutside();
        }
    }

}
