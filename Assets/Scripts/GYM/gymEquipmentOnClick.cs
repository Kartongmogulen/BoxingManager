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

    public bool foamsticks;
    public bool heavybag;

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

        if (foamsticks == true)
        {
            gymScriptsGO.GetComponent<equipmentLevelManager>().chooseFoamsticks();
        }

    }
}
