using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class playerDefenceTestRunner
{
    [TestCase(25, 100, true, 5)]

    public void guardCalculationHeadFlexHeadTrue(int guardHeadStaminaChange, int guardHeadStatAfterLastFight, bool guardFlexibleHeadActive, int guardFlex)
    {
        int result = playerDefence.guardCalculation(guardHeadStaminaChange, guardHeadStatAfterLastFight, guardFlexibleHeadActive, guardFlex);
        Debug.Log("Result: " + result);
        int expectedResult = guardHeadStatAfterLastFight + guardFlex - guardHeadStaminaChange;
        Debug.Log("ExpectedResult: " + expectedResult);
        Assert.AreEqual(expectedResult, result);

    }
    // A Test behaves as an ordinary method
    [TestCase(true, 100, 4)]
    [TestCase(true, 100, 45)]
    [TestCase(true, 100, 4)]
    public void playerGuardHeadFlexIsActiveHead(bool guardFlexibleHeadActive, int guardHeadBeforeChange, int guardFlex)
    {
        int result = playerDefence.guardFlexPartCheck(true, guardHeadBeforeChange, guardFlex);
        int expectedResult = guardHeadBeforeChange + guardFlex;

        Assert.AreEqual(expectedResult, result);
    }

    [TestCase(false, 1, 1)]
    [TestCase(true, 4, 2)]
    public void playerGuardHeadFlexIsNotActiveHead(bool guardFlexibleHeadActive, int guardHeadBeforeChange, int guardFlex)
    {
        int result = playerDefence.guardFlexPartCheck(false, guardHeadBeforeChange, guardFlex);
        int expectedResult = guardHeadBeforeChange;

        Assert.AreEqual(expectedResult, result);
    }

    [TestCase (10, 100)]
    public void correctionGuardForStamina(int guardHeadStaminaChange, int guardHeadStatAfterLastFight) 
    {
        int result = playerDefence.staminaCorrection(guardHeadStaminaChange, guardHeadStatAfterLastFight);
        Debug.Log("Result: " + result);
        int expectedResult = Mathf.RoundToInt(Mathf.Round(guardHeadStatAfterLastFight * guardHeadStaminaChange / 100));
        Debug.Log("ExpectedResult: " + expectedResult);
        Assert.AreEqual(expectedResult, result);

    }
}
