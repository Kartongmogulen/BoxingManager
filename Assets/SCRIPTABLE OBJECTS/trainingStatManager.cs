using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "trainingStatManager", menuName = "trainingStatManager")]
public class trainingStatManager : ScriptableObject 
{
    public List<int> xpPerLvl; //XP som kr�vs f�r att lvl upp
    public int xpLearnOneTwoCombo;

}
