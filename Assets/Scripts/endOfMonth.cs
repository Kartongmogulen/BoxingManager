using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endOfMonth : MonoBehaviour
{
    public int salary;

    public Text moneySalaryText;

    public GameObject gymPanelGO;
    public GameObject endOfMonthPanelGO;
    public GameObject PlayerOne;
    public GameObject rankingsGO;



    public void endOfMonthUpdate()
    {
        endOfMonthPanelGO.SetActive(true);
        gymPanelGO.SetActive(false);
        updateWorkSalaryText();

        rankingsGO.GetComponent<rankingListVisualisation>().updateTextVictoriesLeftBeforeUnlockChampions();
    }

    public void chooseWork()
    {
        GetComponent<moneyManager>().increaseMoney(salary);
        endOfMonthPanelGO.SetActive(false);
        gymPanelGO.SetActive(true);
        GetComponent<endWeekButton>().updateWeekCount();
    }

    public void updateWorkSalaryText()
    {
        moneySalaryText.text = "Work: " + salary + "$";
        
    }
     
}
