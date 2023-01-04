using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gymEquipmentOnClick : MonoBehaviour
{
    public string name;
    public string workoutOneStat;
    public string workoutTwoStat;
    public string workoutThreeStat;

    public string workoutOneStatTwo; //Om det går att träna på två stats samtidigt

    public bool foamsticks;
    public bool heavybag;
    public bool tennisball;
    public bool safetyMattress;
    public bool outside;

    public bool combinedWorkouts;

    public Text nameEquipment;

    public GameObject gymScriptsGO;

    public void OnMouseDown()
    {
        nameEquipment.text = name;
        gymScriptsGO.GetComponent<trainingMeny>().showPossibleWorkouts(workoutOneStat, workoutTwoStat, workoutThreeStat);

        if (heavybag == true)
        {
            nameEquipment.text = name + " Lvl: " + gymScriptsGO.GetComponent<equipmentLevelManager>().lvlHeavyBag;
            gymScriptsGO.GetComponent<equipmentLevelManager>().chooseHeavybag();

        }

        else if (foamsticks == true)
        {
            nameEquipment.text = name + " Lvl: " + gymScriptsGO.GetComponent<equipmentLevelManager>().lvlFoamsticks;
            gymScriptsGO.GetComponent<equipmentLevelManager>().chooseFoamsticks();
            gymScriptsGO.GetComponent<trainingMeny>().showPossibleWorkouts(workoutOneStat, workoutTwoStat, workoutThreeStat);
            
        }

        else if (tennisball == true)
        {
            nameEquipment.text = name + " Lvl: " + gymScriptsGO.GetComponent<equipmentLevelManager>().lvlTennisball;
            gymScriptsGO.GetComponent<equipmentLevelManager>().chooseTennisball();
            gymScriptsGO.GetComponent<trainingMeny>().showPossibleWorkouts(workoutOneStat, workoutTwoStat,"");

        }

        else if (safetyMattress == true)
        {
            nameEquipment.text = name + " Lvl: " + gymScriptsGO.GetComponent<equipmentLevelManager>().lvlSafetyMattress;
            gymScriptsGO.GetComponent<equipmentLevelManager>().chooseSafetyMattress();
            gymScriptsGO.GetComponent<trainingMeny>().showPossibleWorkouts(workoutOneStat, workoutTwoStat, workoutThreeStat);

        }

        else if (outside == true)
        {
            nameEquipment.text = name + " Lvl: " + gymScriptsGO.GetComponent<equipmentLevelManager>().lvlOutside;
            gymScriptsGO.GetComponent<equipmentLevelManager>().chooseOutside();
            gymScriptsGO.GetComponent<trainingMeny>().showPossibleWorkouts(workoutOneStat, workoutTwoStat, workoutThreeStat);

        }

        if (combinedWorkouts == true)
        {
            gymScriptsGO.GetComponent<trainingMeny>().showCombinedWorkoutStat(workoutOneStatTwo);
        }
        else
        {
            gymScriptsGO.GetComponent<trainingMeny>().showCombinedWorkoutStat("");
        }
    }
}
