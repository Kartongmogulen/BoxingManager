using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxRecord : MonoBehaviour
{
    //Hanterar statistiken �ver segrar, oavgjort, f�rluster
    public int victory;
    public int draw;
    public int defeat;

    public int victoryLvlOneOpp; //Antal segrar mot Lvl 1 Opponent. Dessa segrar som g�r det m�jligt att l�sa upp Champion

    public Text boxRecordText;
    

    public void updateBoxRecordText()
    {
        boxRecordText.text = "Box rec: " + victory + "(W) - " + defeat + "(L)";
    }

    
}
