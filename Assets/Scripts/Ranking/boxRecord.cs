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

    public Text boxRecordText;

    public void updateBoxRecordText()
    {
        boxRecordText.text = "Box rec: " + victory + "(W) - " + defeat + "(L)";
    }
}
