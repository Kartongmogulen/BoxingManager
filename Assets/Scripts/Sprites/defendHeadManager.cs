using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class defendHeadManager : MonoBehaviour
{
    public Texture defendHeadSprite;

    public GameObject playerOneDefendHeadPlaceholder;
    public GameObject playerTwoDefendHeadPlaceholder;

    public GameObject playerOneGuardHeadGO;
  

    public GameObject playerTwoGuardHeadGO;
    

    //Player One
    public bool playerOneGuardHeadActive;

    //Player Two
    public bool playerTwoGuardHeadActive;

    private void Start()
    {
        playerOneDefendHeadPlaceholder.SetActive(true);
        playerOneGuardHeadGO.GetComponent<RawImage>().texture = defendHeadSprite;

        playerTwoDefendHeadPlaceholder.SetActive(true);
        playerTwoGuardHeadGO.GetComponent<RawImage>().texture = defendHeadSprite;


    }

    public void resetAfterFight()
    {
        playerOneExtraGuardHeadInactive();
        playerTwoExtraGuardHeadInactive();
    }

    public void playerOneExtraGuardHeadActive()
    {

        playerOneGuardHeadActive = true;
        playerOneGuardHeadGO.GetComponent<RawImage>().enabled = true;
        playerOneGuardHeadGO.SetActive(true);
    }
    public void playerOneExtraGuardHeadInactive() 
    {

        playerOneGuardHeadActive = false;
        playerOneGuardHeadGO.GetComponent<RawImage>().enabled = false;
        playerOneGuardHeadGO.SetActive(false);
    }

    public void playerTwoExtraGuardHeadActive()
    {

        playerTwoGuardHeadActive = true;
        playerTwoGuardHeadGO.GetComponent<RawImage>().enabled = true;
        playerTwoGuardHeadGO.SetActive(true);
    }

    public void playerTwoExtraGuardHeadInactive()
    {

        playerTwoGuardHeadActive = false;
        playerTwoGuardHeadGO.GetComponent<RawImage>().enabled = false;
        playerTwoGuardHeadGO.SetActive(false);
    }

}
