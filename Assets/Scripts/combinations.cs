using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combinations : MonoBehaviour
{
    public attributeManager AttributeManager;
    public int costOneTwoComboExtra; //Kostnaden över standard 1 AP
    public int decreaseAccuracyDodgeCompleted;

    public void oneTwo_JabCrossPlayerOne() 
    {
        if (GetComponent<actionsLeftPlayer>().actionPointsNow >= costOneTwoComboExtra+1)
        {
            GetComponent<actionsLeftPlayer>().subActionPoints(costOneTwoComboExtra);
            GetComponent<fightManager>().playerOneJabHead(false);

            if (GetComponent<jabFight>().dodgeCompletedOrNot == false)
            {
                GetComponent<fightManager>().playerOneCrossHead(AttributeManager.oneTwoAccuracyIncrease[0]);
                Debug.Log("Combo Dodge Fail");
            }
            else
            {
                GetComponent<fightManager>().playerOneCrossHead(decreaseAccuracyDodgeCompleted);
                Debug.Log("Combo Dodge True");
            }
        }
    }

    public void oneTwo_JabCrossPlayerTwo()
    {

        if (GetComponent<actionsLeftPlayer>().actionPointsNow >= costOneTwoComboExtra + 1)
        {
            GetComponent<actionsLeftPlayer>().subActionPoints(costOneTwoComboExtra);
            GetComponent<fightManager>().playerTwoJabHeadCombo();

            if (GetComponent<crossFight>().dodgeCompletedOrNot == false)
            {
                GetComponent<fightManager>().playerTwoCrossHead(AttributeManager.oneTwoAccuracyIncrease[0]);
                Debug.Log("Combo Dodge Fail");
            }
            else
            {
                GetComponent<fightManager>().playerTwoCrossHead(decreaseAccuracyDodgeCompleted);
                Debug.Log("Combo Dodge True");
            }
        }

        /*
        Debug.Log("OneTwoPlayerTwo");
        GetComponent<fightManager>().playerTwoJabHeadCombo();
        GetComponent<fightManager>().playerTwoCrossHead(AttributeManager.oneTwoAccuracyIncrease[0]);
        GetComponent<fightManager>().afterActionChoicePlayerTwo(2);
        */

    }
}
