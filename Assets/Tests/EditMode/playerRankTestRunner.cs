using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class playerRankTestRunner
{
    // A Test behaves as an ordinary method
    [Test]
    [TestCase(3, 0, 0)]
    [TestCase(3, 0, 2)]
    public void checkPlayerLvlZero(int limitToRankUpPlayer, int playerRankedLvl, int VictoriresPlayer)
    {

        int result = playerRank.checkPlayerRank(limitToRankUpPlayer, playerRankedLvl, VictoriresPlayer);

        Assert.AreEqual(0, result);

    }

    // A Test behaves as an ordinary method
    [Test]
    [TestCase(3, 0, 3)]
    [TestCase(3, 1, 3)]
    [TestCase(3, 1, 5)]
    public void checkPlayerLvlOne(int limitToRankUpPlayer, int playerRankedLvl, int pointsNowPlayer)
    {

        int result = playerRank.checkPlayerRank(limitToRankUpPlayer, playerRankedLvl, pointsNowPlayer);

        Assert.AreEqual(1, result);

    }
    
    [TestCase(3, 1, 6)]
    [TestCase(3, 2, 7)]
    public void checkPlayerLvlTwo(int limitToRankUpPlayer, int playerRankedLvl, int pointsNowPlayer)
    {

        int result = playerRank.checkPlayerRank(limitToRankUpPlayer, playerRankedLvl, pointsNowPlayer);

        Assert.AreEqual(2, result);

    }

}
