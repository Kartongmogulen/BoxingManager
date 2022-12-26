using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerXPManager : MonoBehaviour
{
    // Hanterar XP mellan stats lvl upp
    public player PlayerOne;
    public trainingStatManager TrainingStatManager;

    public int accuracyXP;
    public int bodyshotXP;
    public int bodyHealthXP;
    public int dodgeXP;
    public int headHealthXP;
    public int guardBodyXP;
    public int guardFlexXP;
    public int guardHeadXP;
    public int knockdownXP;
    public int strengthXP;

    public void accuracyXPUpdate()
    {
        //Stat lvl upp?
        if (accuracyXP >= TrainingStatManager.xpPerLvl[PlayerOne.accuracy-PlayerOne.accuarcyStartOfGame])
        {
            PlayerOne.accuracy++;
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

    public void bodyHealthXPUpdate()
    {
        //Stat lvl upp?
        if (bodyHealthXP >= TrainingStatManager.xpPerLvl[PlayerOne.playerLvlHealthBody])
        {
            PlayerOne.playerLvlHealthBody++;
            PlayerOne.upgradePlayer();
        }
    }

    public void dodgeXPUpdate()
    {
        //Stat lvl upp?
        if (dodgeXP >= TrainingStatManager.xpPerLvl[PlayerOne.dodge])
        {
            PlayerOne.dodge++;
        }
    }

    public void headHealthXPUpdate()
    {
        //Stat lvl upp?
        if (headHealthXP >= TrainingStatManager.xpPerLvl[PlayerOne.playerLvlHealthHead])
        {
            PlayerOne.playerLvlHealthHead++;
            PlayerOne.upgradePlayer();
        }
    }

    public void guardBodyXPUpdate()
    {
        //Stat lvl upp?
        if (guardBodyXP >= TrainingStatManager.xpPerLvl[PlayerOne.guardBody - 1]) //Justeras då startStat är 1
        {
            PlayerOne.guardBody++;
            PlayerOne.upgradePlayer();
        }
    }

    public void guardFlexXPUpdate()
    {
        //Stat lvl upp?
        if (guardFlexXP >= TrainingStatManager.xpPerLvl[PlayerOne.guardFlexibleDuringFight])
        {
            PlayerOne.guardFlexibleDuringFight++;
            PlayerOne.upgradePlayer();
        }
    }

    public void guardHeadXPUpdate()
    {
        //Stat lvl upp?
        if (guardHeadXP >= TrainingStatManager.xpPerLvl[PlayerOne.guardHead-1]) //Justeras då startStat är 1
        {
            PlayerOne.guardHead++;
            PlayerOne.upgradePlayer();
        }
    }

    

    public void knockdownXPUpdate()
    {
        //Stat lvl upp?
        if (knockdownXP >= TrainingStatManager.xpPerLvl[PlayerOne.knockdownChance])
        {
            PlayerOne.knockdownChance++;
        }
    }

    public void strengthXPUpdate()
    {
        //Stat lvl upp?
        if (strengthXP >= TrainingStatManager.xpPerLvl[PlayerOne.strength - PlayerOne.strengthStartOfGame])
        {
            PlayerOne.strength++;
        }
    }

}
