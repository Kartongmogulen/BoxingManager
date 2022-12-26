using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClickTennisball : MonoBehaviour
{
    public string name;
    public string workoutOneStat;
    public string workoutTwoStat;
    
    public Text nameEquipment;

    public GameObject gymScriptsGO;

    public void OnMouseDown()
    {
        nameEquipment.text = name;
        gymScriptsGO.GetComponent<trainingMeny>().showPossibleWorkouts(workoutOneStat, workoutTwoStat,"");
    }

}
