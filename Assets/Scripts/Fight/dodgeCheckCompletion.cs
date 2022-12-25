using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgeCheckCompletion : MonoBehaviour
{
    //Kontrollerar om dodge lyckas
    public int extraPointsForAttacker; //Svårare med Dodge så addera poäng som krävs för att försvaren ska lyckas
    
    public int randomAttacker;
    public int randomDefender;
    public bool checkIfDodgeSucced(int attackersAccuracy, int defendersDodge)
    {
        //Debug.Log("Script för Dodge");
        randomAttacker = Random.Range(1, attackersAccuracy + extraPointsForAttacker);
        //randomAttacker = 2; // ENDAST FÖR TEST
        //randomDefender = 1; // ENDAST FÖR TEST
        //Debug.Log("Attacker: " + randomAttacker);
        randomDefender = Random.Range(1, defendersDodge + 1);
        //Debug.Log("Försvar: " + randomDefender);
        if (randomAttacker  < randomDefender)
            return true;
        else
            return false;
    }
}
