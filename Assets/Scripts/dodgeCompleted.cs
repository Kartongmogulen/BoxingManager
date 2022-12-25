using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgeCompleted : MonoBehaviour
{
    //Genomf�rs n�r Dodge lyckas
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
        //Debug.Log("Next players turn in DodgeCompleded");
        fightScriptsGO.GetComponent<actionsLeftPlayer>().resetActionPoints();
        fightScriptsGO.GetComponent<actionsLeftPlayer>().actionPointsNow++; //"FUL-L�SNING" N�r motst�ndaren lyckades med Dodge gjorde bara motst�ndaren 2 actions
        //fightScriptsGO.GetComponent<fightManager>().startCheckIfNextRoundCanStart();
    }

}
