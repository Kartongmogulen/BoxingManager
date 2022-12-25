using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodgeMechanicManager : MonoBehaviour
{
    public bool dodgeMechanicActive;
    public bool dodgeSuccedNextPlayersTurn;
    public GameObject dodgeFightPanel;
    

    private void Start()
    {
        if (dodgeMechanicActive == false)
        {
            dodgeFightPanel.SetActive(false);
        }
    }
}
