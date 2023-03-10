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
    public bool foamsticksActive;

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

            else if (foamsticksActive == true)
            {
                EquipmentLevelManager.lvlFoamsticks++;
                EquipmentLevelManager.foamsticksLvlUp();
            }

            else if (EquipmentLevelManager.tennisballActive == true)
            {
                EquipmentLevelManager.lvlTennisball++;
                //EquipmentLevelManager.tennisballLvlUp();
            }

            else if (EquipmentLevelManager.safetyMattressActive == true)
            {
                EquipmentLevelManager.lvlSafetyMattress++;
                //EquipmentLevelManager.tennisballLvlUp();
            }

            else if (EquipmentLevelManager.outsideActive == true)
            {
                EquipmentLevelManager.lvlOutside++;
                //EquipmentLevelManager.tennisballLvlUp();
            }
        }
    }

    public void enoughMoney()
    {
        lvlNowEquipment = checkLvlNowEquipment();
        //Debug.Log("Lvl now: " + lvlNowEquipment);

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

        if (EquipmentLevelManager.foamsticksActive == true)
        {
            lvlNowEquipment = EquipmentLevelManager.lvlFoamsticks;
            foamsticksActive = true;
        }

        if (EquipmentLevelManager.tennisballActive == true)
        {
            lvlNowEquipment = EquipmentLevelManager.lvlTennisball;
        }

        if (EquipmentLevelManager.safetyMattressActive == true)
        {
            lvlNowEquipment = EquipmentLevelManager.lvlSafetyMattress;
        }

        if (EquipmentLevelManager.outsideActive == true)
        {
            lvlNowEquipment = EquipmentLevelManager.lvlOutside;
        }

        return lvlNowEquipment;
    }

    public void inactiveEquipment()
    {
        heavybagActive = false;
        foamsticksActive = false;
    }
}
