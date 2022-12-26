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

    public Text nameEquipment;

    public GameObject gymScriptsGO;

    public void OnMouseDown()
    {
        nameEquipment.text = name;
        gymScriptsGO.GetComponent<trainingMeny>().showPossibleWorkouts(workoutOneStat, workoutTwoStat, workoutThreeStat);

    }
}
