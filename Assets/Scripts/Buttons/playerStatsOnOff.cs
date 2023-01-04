using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatsOnOff : MonoBehaviour
{
    public GameObject playerPanelGO;
    public bool playerPanelOn;

    public void turnOnOff()
    {
        if (playerPanelOn == false)
        {
            playerPanelGO.SetActive(true);
            playerPanelOn = true;
        }
        else
        {
            playerPanelGO.SetActive(false);
            playerPanelOn = false;
        }
    }

}
