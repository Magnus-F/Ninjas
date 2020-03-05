using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        else if (theLevelManager.goldCoinCount >= 5 && !canUseRed)
        {
            canUseRed = true;
            theLevelManager.currentColor = "Red";
            theLevelManager.towerSegmentToUse = theLevelManager.redTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.redNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.redButton.GetComponentInChildren<Text>().text = "Red (Bought)";
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
        else if (theLevelManager.goldCoinCount >= 5 && !canUseGreen)
        {
            canUseGreen = true;
            theLevelManager.currentColor = "Green";
            theLevelManager.towerSegmentToUse = theLevelManager.greenTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.greenNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.greenButton.GetComponentInChildren<Text>().text = "Green (Bought)";
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
        else if (theLevelManager.goldCoinCount >= 5 && !canUseBlue)
        {
            canUseBlue = true;
            theLevelManager.currentColor = "Blue";
            theLevelManager.towerSegmentToUse = theLevelManager.blueTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.blueNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.blueButton.GetComponentInChildren<Text>().text = "Blue (Bought)";
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
        else if (theLevelManager.goldCoinCount >= 5 && !canUseYellow)
        {
            canUseYellow = true;
            theLevelManager.currentColor = "Yellow";
            theLevelManager.towerSegmentToUse = theLevelManager.yellowTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.yellowNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.yellowButton.GetComponentInChildren<Text>().text = "Yellow (Bought)";
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
        else if (theLevelManager.goldCoinCount >= 5 && !canUseBlack)
        {
            canUseBlack = true;
            theLevelManager.currentColor = "Black";
            theLevelManager.towerSegmentToUse = theLevelManager.blackTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.blackNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.blackButton.GetComponentInChildren<Text>().text = "Black (Bought)";
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
        else if (theLevelManager.goldCoinCount >= 5 && !canUsePurple)
        {
            canUsePurple = true;
            theLevelManager.currentColor = "Purple";
            theLevelManager.towerSegmentToUse = theLevelManager.purpleTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.purpleNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.purpleButton.GetComponentInChildren<Text>().text = "Purple (Bought)";
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
        else if (theLevelManager.goldCoinCount >= 5 && !canUseIndigo)
        {
            canUseIndigo = true;
            theLevelManager.currentColor = "Indigo";
            theLevelManager.towerSegmentToUse = theLevelManager.indigoTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.indigoNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.indigoButton.GetComponentInChildren<Text>().text = "Indigo (Bought)";
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
        else if (theLevelManager.goldCoinCount >= 5 && !canUsePink)
        {
            canUsePink = true;
            theLevelManager.currentColor = "Pink";
            theLevelManager.towerSegmentToUse = theLevelManager.pinkTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.pinkNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.pinkButton.GetComponentInChildren<Text>().text = "Pink (Bought)";
        }
    }
}
