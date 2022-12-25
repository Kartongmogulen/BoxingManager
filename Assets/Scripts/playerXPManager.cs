using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerXPManager : MonoBehaviour
{
    // Hanterar XP mellan stats lvl upp
    public player PlayerOne;
    public trainingStatManager TrainingStatManager;
    
    public int knockdownXP;
    public int bodyshotXP;

    public void knockdownXPUpdate()
    {
        //Stat lvl upp?
        if (knockdownXP >= TrainingStatManager.xpPerLvl[PlayerOne.knockdownChance])
        {
            PlayerOne.knockdownChance++;
        }
    }

    public void bodyshotXPUpdate()
    {
        //Stat lvl upp?
        if (bodyshotXP >= TrainingStatManager.xpPerLvl[PlayerOne.reduceOpponentStaminaRecoveryChance])
        {
            PlayerOne.reduceOpponentStaminaRecoveryChance++;
        }
    }
}
