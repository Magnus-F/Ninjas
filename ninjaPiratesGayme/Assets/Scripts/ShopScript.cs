using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public LevelManager theLevelManager;
    public bool canUseRed;
    public bool canUseGreen;
    public bool canUseBlue;
    public bool canUseYellow;
    public bool canUseBlack;
    public bool canUsePurple;
    public bool canUseIndigo;
    public bool canUsePink;

    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();

        canUseRed = false;
        canUseGreen = false;
        canUseBlue = false;
        canUseYellow = false;
        canUseBlack = false;
        canUsePurple = false;
        canUseIndigo = false;
        canUsePink = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DefaultButton()
    {
        theLevelManager.currentColor = "Default";
        theLevelManager.towerSegmentToUse = theLevelManager.defaultTowerSegment;
        theLevelManager.ninjaStarToUse = theLevelManager.defaultNinjaStar;
    }

    public void RedButton()
    {
        if (canUseRed)
        {
            theLevelManager.currentColor = "Red";
            theLevelManager.towerSegmentToUse = theLevelManager.redTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.redNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 3 && !canUseRed)
        {
            canUseRed = true;
            theLevelManager.currentColor = "Red";
            theLevelManager.towerSegmentToUse = theLevelManager.redTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.redNinjaStar;
            theLevelManager.goldCoinCount -= 3;
        }
    }

    public void GreenButton()
    {
        if (canUseGreen)
        {
            theLevelManager.currentColor = "Green";
            theLevelManager.towerSegmentToUse = theLevelManager.greenTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.greenNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 3 && !canUseGreen)
        {
            canUseGreen = true;
            theLevelManager.currentColor = "Green";
            theLevelManager.towerSegmentToUse = theLevelManager.greenTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.greenNinjaStar;
            theLevelManager.goldCoinCount -= 3;
        }
    }

    public void BlueButton()
    {
        if (canUseBlue)
        {
            theLevelManager.currentColor = "Blue";
            theLevelManager.towerSegmentToUse = theLevelManager.blueTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.blueNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 3 && !canUseBlue)
        {
            canUseBlue = true;
            theLevelManager.currentColor = "Red";
            theLevelManager.towerSegmentToUse = theLevelManager.redTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.redNinjaStar;
            theLevelManager.goldCoinCount -= 3;
        }
    }

    public void YellowButton()
    {
        if (canUseYellow)
        {
            theLevelManager.currentColor = "Yellow";
            theLevelManager.towerSegmentToUse = theLevelManager.yellowTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.yellowNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 3 && !canUseYellow)
        {
            canUseYellow = true;
            theLevelManager.currentColor = "Yellow";
            theLevelManager.towerSegmentToUse = theLevelManager.yellowTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.yellowNinjaStar;
            theLevelManager.goldCoinCount -= 3;
        }
    }

    public void BlackButton()
    {
        if (canUseBlack)
        {
            theLevelManager.currentColor = "Black";
            theLevelManager.towerSegmentToUse = theLevelManager.blackTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.blackNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 3 && !canUseBlack)
        {
            canUseBlack = true;
            theLevelManager.currentColor = "Black";
            theLevelManager.towerSegmentToUse = theLevelManager.blackTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.blackNinjaStar;
            theLevelManager.goldCoinCount -= 3;
        }
    }

    public void PurpleButton()
    {
        if (canUsePurple)
        {
            theLevelManager.currentColor = "Purple";
            theLevelManager.towerSegmentToUse = theLevelManager.purpleTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.purpleNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 3 && !canUsePurple)
        {
            canUsePurple = true;
            theLevelManager.currentColor = "Purple";
            theLevelManager.towerSegmentToUse = theLevelManager.purpleTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.purpleNinjaStar;
            theLevelManager.goldCoinCount -= 3;
        }
    }

    public void IndigoButton()
    {
        if (canUseIndigo)
        {
            theLevelManager.currentColor = "Indigo";
            theLevelManager.towerSegmentToUse = theLevelManager.indigoTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.indigoNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 3 && !canUseIndigo)
        {
            canUseIndigo = true;
            theLevelManager.currentColor = "Indigo";
            theLevelManager.towerSegmentToUse = theLevelManager.indigoTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.indigoNinjaStar;
            theLevelManager.goldCoinCount -= 3;
        }
    }

    public void PinkButton()
    {
        if (canUsePink)
        {
            theLevelManager.currentColor = "Pink";
            theLevelManager.towerSegmentToUse = theLevelManager.pinkTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.pinkNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 3 && !canUsePink)
        {
            canUsePink = true;
            theLevelManager.currentColor = "Pink";
            theLevelManager.towerSegmentToUse = theLevelManager.pinkTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.pinkNinjaStar;
            theLevelManager.goldCoinCount -= 3;
        }
    }
}
