using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createOpponent : MonoBehaviour
{
    //Skapar motståndare utifrån lvl
    //Slumpar sedan fram vilka attribut där poängen ska delas ut

    public playerList PlayerList;
    public attributeLevelManager AttributeLevelManager;
    public attributeManager AttributeManager;
    public player Player;
    //public fightStyleSO FightStyleSO;
    public createOpponentAttributeList CreateOpponentAttributeList;

    public int lvlOpponent;

    public int fightStyleValue;

    public int randomInt;

    private void Start()
    {

        Player = GetComponent<player>();
        
        //AttributeLevelManager = PlayerList.GetComponent<attributeLevelManager>();
        createOpponentFunction();
        
        //randomizePoints(lvlOpponent);
        //bodyHealth = AttributeLevelManager.bodyHealth[0];
        //setLvl();
    }

    public void setLvl(int setLvlInt)
    {
        GetComponent<player>().playerLvl = setLvlInt;
        lvlOpponent = setLvlInt;
        
    }

    public void createOpponentFunction()
    {
        fightStyle();
        staminaLvlChange();
        GetComponent<player>().Opponent = true;

        attackFocus();
        bodyHead();
        healthHead();
        dodge();
        accuracyAndStrength(CreateOpponentAttributeList.accuracyAndStrengthPointsToShare[lvlOpponent]);
        bodySnatcherAndKO(CreateOpponentAttributeList.bodysnatcherAndKOPointsToShareMin[lvlOpponent], CreateOpponentAttributeList.bodysnatcherAndKOPointsToShareMax[lvlOpponent]);
        guardPoints(CreateOpponentAttributeList.guardPointsToShare[lvlOpponent]);
        guardFlexiblePoints(CreateOpponentAttributeList.guardFlexibleMin[lvlOpponent], CreateOpponentAttributeList.guardFlexiblePointsToShare[lvlOpponent]);
        combinations();
        GetComponent<player>().Awake();
        //Debug.Log("CreateOpponent");
    }

    public void fightStyle()
    {
        //Vid denna lvl kan inte motståndaren ha någon FightStyle
        if (lvlOpponent == 0)
        {
            GetComponent<player>().fightStyleNow = (global::fightStyle)0;
        }

       else if (GetComponent<player>().fightStyleNow > 0)
        {
            return;
        }

        else
        {
            fightStyleValue = Random.Range(1, System.Enum.GetValues(typeof(fightStyle)).Length);
            //Debug.Log(GetComponent<player>().name + " " + fightStyleValue);
            GetComponent<player>().fightStyleNow = (global::fightStyle)fightStyleValue;
            //Debug.Log("FightStyle: " + GetComponent<player>().fightStyleNow);
        }
    }

    public void staminaLvlChange()
    {
        GetComponent<player>().playerLvlHealthStamina = GetComponent<player>().playerLvl;

        if (GetComponent<player>().fightStyleNow.ToString() == "Slugger")
        {
            GetComponent<player>().playerLvlHealthStamina = GetComponent<player>().playerLvl + AttributeManager.sluggerStaminaChange;
            //Debug.Log("StaminaLvlChange Slugger");
        }

        //Debug.Log("StaminaLvl: " + GetComponent<player>().playerLvlHealthStamina);

    }

    public void attackFocus()
    {
        randomInt = Random.Range(0, 2);
        GetComponent<player>().AttackFocus = (global::attackFocus)randomInt;

    }

    public void accuracyAndStrength(int pointsToShare)
    {
        //Debug.Log("Poäng att dela på: " + pointsToShare);

        //Accuracy tilldelning
        randomInt = Random.Range(0, pointsToShare);
        //Debug.Log("RandomInt: " + randomInt);
        Player.accuracy = CreateOpponentAttributeList.accuracyMin + randomInt;

        //Strength tilldelning
        randomInt = pointsToShare - randomInt;
        //Debug.Log("RandomInt: " + randomInt);
        Player.strength = CreateOpponentAttributeList.strengthMin + randomInt;

        if (GetComponent<player>().fightStyleNow.ToString() == "Boxerpuncher")
        {
            Player.accuracy += AttributeManager.boxerpuncherStatBoostAccuracy * (lvlOpponent + 1);
            Player.strength += AttributeManager.boxerpuncherStatBoostStrength * (lvlOpponent + 1);
        }

        if (GetComponent<player>().fightStyleNow.ToString() == "Slugger")
        {
            Player.strength += AttributeManager.sluggerStatBoostStrength * (lvlOpponent + 1);
            //Debug.Log(Player.name + " Accuracy: " + Player.accuracy);
            Player.accuracy += AttributeManager.sluggerAccuracyChange;
            //Debug.Log(Player.name + "Accuracy: " + Player.accuracy);
        }
        //Debug.Log("CreateOpponent Accuracy: " + Player.accuracy); //EJ FEL GÄLLANDE NOLLSTÄLLNING AV STAT TY DENNA UFFÖRS VID START
        Player.accuracyStatAfterLastFight = Player.accuracy;
        Player.strengthStatAfterLastFight = Player.strength;
    }

    public void bodyHead()
    {
        GetComponent<player>().playerLvlHealthBody = lvlOpponent;

        if (GetComponent<player>().fightStyleNow.ToString() == "Slugger")
        {
            Player.playerLvlHealthBody += AttributeManager.sluggerHealthBodyLvlChange;
        }
    }

    public void healthHead()
    {

        GetComponent<player>().playerLvlHealthHead = lvlOpponent;

        if (GetComponent<player>().fightStyleNow.ToString() == "Slugger")
        {
            Player.playerLvlHealthHead += AttributeManager.sluggerHealthHeadLvlChange;
            //Debug.Log("createOpp-script" + Player.playerLvlHealthHead);
        }
    }

    public void dodge()
    {
        if (GetComponent<player>().fightStyleNow.ToString() == "Counterpuncher")
        {
            Player.dodge += AttributeManager.counterpuncherDodgeBoost * (lvlOpponent + 1);
            dodgeActiveStart();
        }

       
    }

    public void dodgeActiveStart()
    {
        GetComponent<player>().dodgeActive = true;
    }

    public void bodySnatcherAndKO(int min, int max)
    {

        randomInt = Random.Range(min, max);
        //Debug.Log("RandomInt: " + randomInt);

        Player.knockdownChance = randomInt;

        if (randomInt == max)
        {
            //Debug.Log("KO max: " + randomInt);
            Player.reduceOpponentStaminaRecoveryChance = min;
        }
        else
        {
            randomInt = Random.Range(min, max-randomInt);
            Player.reduceOpponentStaminaRecoveryChance = randomInt;
            //Debug.Log("RandomInt: " + randomInt);
        }

        Player.knockdownChanceStatAfterLastFight = Player.knockdownChance;
        Player.reduceOpponentStaminaRecoveryChanceStatAfterLastFight = Player.reduceOpponentStaminaRecoveryChance;

    }

    public void guardPoints(int pointsToShare)
    {
        randomInt = Random.Range(0, pointsToShare);
        Player.guardHead = CreateOpponentAttributeList.guardMin[lvlOpponent] + randomInt;
        Player.guardHeadStatAfterLastFight = Player.guardHead;

        //Återstående poäng tilldelas här
        randomInt = pointsToShare - randomInt;
        Player.guardBody = CreateOpponentAttributeList.guardMin[lvlOpponent] + randomInt;
        Player.guardBodyStatAfterLastFight = Player.guardBody;
    }

    public void guardFlexiblePoints(int min, int max)
    {
        randomInt = Random.Range(min, max);
        Player.guardFlexibleDuringFight = randomInt;
    }

    public void combinations()
    {
        //OneTwo-Combo
        randomInt = Random.Range(0, 100);
        if (randomInt < CreateOpponentAttributeList.oneTwoComboProb[lvlOpponent])
        {
            Player.oneTwoUnlocked = true;
        }
    }

    /*
    public void randomizePoints(int lvlOpponent)
    {
    
        if (lvlOpponent> maxLvlPerAttribute)
        randomInt = Random.Range(0, maxLvlPerAttribute);
        else
        randomInt = Random.Range(0, lvlOpponent);

        bodyHealth = AttributeLevelManager.bodyHealthByLvl[randomInt];
    }
    */
}
    



