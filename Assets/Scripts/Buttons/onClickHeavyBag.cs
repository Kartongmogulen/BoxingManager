using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClickHeavyBag : MonoBehaviour
{
    public string name;
    public string workoutOneStat;

    public Text nameEquipment;
    public Text workoutOneStatName;

    public GameObject gymScriptsGO;

    

    public void OnMouseDown()
    {
        nameEquipment.text = name;
        workoutOneStatName.text = workoutOneStat;

        gymScriptsGO.GetComponent<activeWorkout>().knockout = true;
    }
}
