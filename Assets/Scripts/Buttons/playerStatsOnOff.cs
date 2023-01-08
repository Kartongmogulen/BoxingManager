using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatsOnOff : MonoBehaviour
{
    public GameObject playerPanelGO;
    public bool playerPanelOn;

    public GameObject heavybagTextGO;
    public GameObject foamsticksTextGO;
   

    public void turnOnOff()
    {
        if (playerPanelOn == false)
        {
            playerPanelGO.SetActive(true);
            playerPanelOn = true;
            gymUIOff();
        }
        else
        {
            playerPanelGO.SetActive(false);
            playerPanelOn = false;
            gymUIOn();
        }
    }

    public void gymUIOff()
    {
        heavybagTextGO.SetActive(false);
        foamsticksTextGO.SetActive(false);
    }

    public void gymUIOn()
    {
        heavybagTextGO.SetActive(true);
        foamsticksTextGO.SetActive(true);
    }

}
