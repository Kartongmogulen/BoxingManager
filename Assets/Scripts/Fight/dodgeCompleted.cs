using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgeCompleted : MonoBehaviour
{
    //Genomförs när Dodge lyckas
    public GameObject GameLoopGO;
    public GameObject fightScriptsGO;
    public dodgeMechanicManager DodgeMechanicManager;
   

    private void Start()
    {
        DodgeMechanicManager = GameLoopGO.GetComponent< dodgeMechanicManager >();
    }

    public void whatActionAfterSuccededDodge()
    {
        if  (DodgeMechanicManager.dodgeSuccedNextPlayersTurn == true)
        {
            nextPlayersTurn();
        }
    }

    public void nextPlayersTurn()
    {
        Debug.Log("Next players turn in DodgeCompleded");
     
    }

}
