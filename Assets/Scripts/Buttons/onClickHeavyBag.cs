using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClickHeavyBag : MonoBehaviour
{
    public string name;
    public string workoutOneStat;
    public string workoutTwoStat;

    //public int heavyBagKnockdownWorkoutXP; //Hur mycket XP som erhålls per träningspass
   
    //public Button buttonOne;

    public Text nameEquipment;

    public GameObject gymScriptsGO;

    

    public void OnMouseDown()
    {
        nameEquipment.text = name;
        //workoutOneStatName.text = workoutOneStat;

        gymScriptsGO.GetComponent<trainingMeny>().showPossibleWorkouts(workoutOneStat, workoutTwoStat, "");

        //gymScriptsGO.GetComponent<activeWorkout>().knockout = true;
    }

    /*
    public void buttonOneKO()
    {
        gymScriptsGO.GetComponent<activeWorkout>().knockout = true;


    }
    */
}
