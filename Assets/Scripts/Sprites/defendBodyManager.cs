using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class defendBodyManager : MonoBehaviour
{

    public Texture defendSprite;

    public GameObject playerOneDefendBodyPlaceholder;
    public GameObject playerTwoDefendBodyPlaceholder;

    public GameObject playerOneGuardBodyGO;

    public GameObject playerTwoGuardBodyGO;

    //Player One
    public bool playerOneGuardBodyActive;

    //Player Two
    public bool playerTwoGuardBodyActive;

    // Start is called before the first frame update
    private void Start()
    {
        playerOneDefendBodyPlaceholder.SetActive(true);
        playerOneGuardBodyGO.GetComponent<RawImage>().texture = defendSprite;

        playerTwoDefendBodyPlaceholder.SetActive(true);
        playerTwoGuardBodyGO.GetComponent<RawImage>().texture = defendSprite;

    }

    public void resetAfterFight()
    {
        playerOneExtraGuardInactive();
        playerTwoExtraGuardBodyInactive();
    }

    public void playerOneExtraGuardActive()
    {

        playerOneGuardBodyActive = true;
        playerOneGuardBodyGO.GetComponent<RawImage>().enabled = true;
        playerOneGuardBodyGO.SetActive(true);
    }

    public void playerOneExtraGuardInactive()
    {

        playerOneGuardBodyActive = false;
        playerOneGuardBodyGO.GetComponent<RawImage>().enabled = false;
        playerOneGuardBodyGO.SetActive(false);
    }

    public void playerTwoExtraGuardActive()
    {

        playerTwoGuardBodyActive = true;
        playerTwoGuardBodyGO.GetComponent<RawImage>().enabled = true;
        playerTwoGuardBodyGO.SetActive(true);
    }

    public void playerTwoExtraGuardBodyInactive()
    {

        playerTwoGuardBodyActive = false;
        playerTwoGuardBodyGO.GetComponent<RawImage>().enabled = false;
        playerTwoGuardBodyGO.SetActive(false);
    }
}
