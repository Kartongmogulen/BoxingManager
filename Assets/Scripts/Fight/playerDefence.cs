using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDefence : MonoBehaviour
{

    public int guardHead;
    public int guardHeadStatAfterLastFight;//Stat efter senaste matchen, går ej att gå lägre än detta.
    public bool guardFlexibleHeadActive;
    public int guardHeadCorrectedForStamina;
   
    public int guardBody;
    public int guardBodyStatAfterLastFight;//Stat efter senaste matchen, går ej att gå lägre än detta.
    
    public bool guardFlexibleBodyActive;
    public int guardFlexibleDuringFight;
    public int guardFlexibleDuringFightAfterLastFight; //Stat efter senaste matchen, går ej att gå lägre än detta.

    public static int guardCalculation(int guardPartStaminaChange, int guardParttStatAfterLastFight, bool guardFlexiblePartActive, int guardFlex)
    {
        int guardPart = guardParttStatAfterLastFight;

        Debug.Log("guardPartStaminaChange: " + guardPartStaminaChange);

        //Korrigering för Stamina
        int guardPartCorrectedForStamina = staminaCorrection(guardPartStaminaChange, guardParttStatAfterLastFight);
        int guardPartAfterStaminaChange = guardParttStatAfterLastFight - guardPartCorrectedForStamina;

        //Korrigering för GuardFlex
        guardPart = guardFlexPartCheck(guardFlexiblePartActive, guardPartAfterStaminaChange, guardFlex);

        return guardPart;
    }

    public static int staminaCorrection(int guardStaminaChange, int guardStatAfterLastFight)
    {
        //int correctGuardForStamina = 0;

        int correctGuardForStamina = Mathf.RoundToInt(Mathf.Round(guardStatAfterLastFight * guardStaminaChange/100));
        Debug.Log("GuardEfterStaminaCorrection: " + correctGuardForStamina);

        return correctGuardForStamina;

    }

    public static int guardFlexPartCheck(bool guardFlexiblePartActive, int guardPartBeforeChange, int guardFlex)
    {
        int guardHead = 0;
        if (guardFlexiblePartActive == true)
        {
            guardHead = guardPartBeforeChange + guardFlex;
        }

        else 
        {
            guardHead = guardPartBeforeChange;
        }

        //Debug.Log("Guard Head: " + guardHead);

        return guardHead;
    }

    /*
    public static int guardFlexBodyCheck(bool guardFlexibleBodyActive, int guardBodyBeforeChange, int guardFlex)
    {
        int guardBody = 0;
        Debug.Log("guardFlexHeadCheck");
        if (guardFlexibleBodyActive == true)
        {
            guardBody = guardBodyBeforeChange + guardFlex;
        }

        else
        {
            guardBody = guardBodyBeforeChange;
        }

        Debug.Log("Guard Head: " + guardBody);

        return guardBody;
    }
    */
}
