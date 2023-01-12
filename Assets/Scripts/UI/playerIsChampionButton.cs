using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerIsChampionButton : MonoBehaviour
{
    //Hanterar vad som händer med knappen när Spelaren besegrar Champion
    public Button chooseChampionButton;
    public Text chooseChampionText;


    public void playerIsNowTheChampion()
    {
        chooseChampionButton.GetComponent<Image>().color = Color.green;
        chooseChampionButton.GetComponent<Button>().interactable = false;
        chooseChampionText.text = "You are the champion!";

    }
}
