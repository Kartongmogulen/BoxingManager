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



    public void endOfMonthUpdate()
    {
        endOfMonthPanelGO.SetActive(true);
        gymPanelGO.SetActive(false);
        updateWorkSalaryText();
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
