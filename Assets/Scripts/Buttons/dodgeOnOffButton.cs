using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dodgeOnOffButton : MonoBehaviour
{
    public player Player;
    public Text dodgeActiveText;

    public void buttonClickDodge()
    {
        if (Player.dodgeActive == false)
        {
            Player.dodgeActive = true;
            dodgeActiveText.text = "Dodge: Active";
        }

        else
        {
            Player.dodgeActive = false;
            dodgeActiveText.text = "Dodge: OFF";
        }
    }

    public void startFight()
    {
        Player.dodgeActive = false;
        dodgeActiveText.text = "Dodge: OFF";
    }
}
