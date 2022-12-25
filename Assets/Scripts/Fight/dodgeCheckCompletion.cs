using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgeCheckCompletion : MonoBehaviour
{
    //Kontrollerar om dodge lyckas
    public int extraPointsForAttacker; //Sv�rare med Dodge s� addera po�ng som kr�vs f�r att f�rsvaren ska lyckas
    
    public int randomAttacker;
    public int randomDefender;
    public bool checkIfDodgeSucced(int attackersAccuracy, int defendersDodge)
    {
        //Debug.Log("Script f�r Dodge");
        randomAttacker = Random.Range(1, attackersAccuracy + extraPointsForAttacker);
        //randomAttacker = 2; // ENDAST F�R TEST
        //randomDefender = 1; // ENDAST F�R TEST
        //Debug.Log("Attacker: " + randomAttacker);
        randomDefender = Random.Range(1, defendersDodge + 1);
        //Debug.Log("F�rsvar: " + randomDefender);
        if (randomAttacker  < randomDefender)
            return true;
        else
            return false;
    }
}
