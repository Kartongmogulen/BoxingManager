using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyLvlUpEquipment : MonoBehaviour
{
    public moneyManager MoneyManager;
    public equipmentLevelManager EquipmentLevelManager;

    public int lvlNowEquipment;

    public bool lvlUpOrNot;

    public bool heavybagActive;

    public void lvlUp()
    {
        enoughMoney();
        if (lvlUpOrNot == true)
        {
            MoneyManager.decreaseMoney(EquipmentLevelManager.equipmentLvlCost[lvlNowEquipment]);
            
            //VILKET REDSKAP SOM SKA UPPGRADERAS
            if (heavybagActive == true)
            {
                EquipmentLevelManager.lvlHeavyBag++;
                EquipmentLevelManager.heavybagLvlUp();
            }
        }
    }

    public void enoughMoney()
    {
        lvlNowEquipment = checkLvlNowEquipment();
        Debug.Log("Lvl now: " + lvlNowEquipment);

        if (MoneyManager.moneyNow >= EquipmentLevelManager.equipmentLvlCost[lvlNowEquipment])
        {
            lvlUpOrNot = true;
        }

        else
            lvlUpOrNot = false;

    }

    public int checkLvlNowEquipment()
    {
        inactiveEquipment();

        if  (EquipmentLevelManager.heavybagActive == true)
        {
            lvlNowEquipment = EquipmentLevelManager.lvlHeavyBag;
            heavybagActive = true;
        }

        return lvlNowEquipment;
    }

    public void inactiveEquipment()
    {
        heavybagActive = false;
    }
}
