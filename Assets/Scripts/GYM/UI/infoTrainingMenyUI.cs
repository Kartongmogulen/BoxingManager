using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoTrainingMenyUI : MonoBehaviour
{
    public GameObject descriptionPanelGO;
    public player PlayerOne;
    public Text description;
    public attributeManager AttributeManager;
    public activeWorkout ActiveWorkout;

    public void activateDescriptionPanel()
    {
        descriptionPanelGO.SetActive(true);

        if (ActiveWorkout.oneTwoCombo == true)
        {
            descriptionTextCombo(PlayerOne.oneTwoComboLvl, true);
        }
    }

    public void descriptionTextCombo(int lvl, bool oneTwoCombo)
    {
        if (oneTwoCombo == true)
        {
            description.text = "A Jab followed by a Cross. Increase the Accuracy of the Cross by " + AttributeManager.oneTwoAccuracyIncrease[lvl];
        }
    }
}
