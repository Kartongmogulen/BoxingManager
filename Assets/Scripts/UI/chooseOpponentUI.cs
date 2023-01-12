using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseOpponentUI : MonoBehaviour
{
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject buttonThree;

    public void showOnlyButtonOne()
    {
        buttonOne.SetActive(true);
        buttonTwo.SetActive(false);
        buttonThree.SetActive(false);
    }

    public void activateAll()
    {
        buttonOne.SetActive(true);
        buttonTwo.SetActive(true);
        buttonThree.SetActive(true);
    }
}
