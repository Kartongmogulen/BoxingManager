using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "attributeManager", menuName = "AttributeManager")]
public class attributeManager : ScriptableObject
{
    [Header("Boxerpuncher")]
    public int boxerpuncherStatBoostAccuracy;
    public int boxerpuncherStatBoostStrength;

    [Header("Slugger")]
    public int sluggerStatBoostStrength;
    public int sluggerAccuracyChange;
    public int sluggerStaminaChange;
    public int sluggerHealthHeadLvlChange;
    public int sluggerHealthBodyLvlChange;

    [Header("Counterpuncher")]
    public int counterpuncherDodgeBoost;

    [Header("Guard")]
    public int costGuardFlexibleDuringFight;

    [Header("Combos")]
    public int[] oneTwoAccuracyIncrease;
    public int oneTwoCostUnlock;
    public List<int> oneTwoCostToLvlUp;
}
