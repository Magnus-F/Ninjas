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

    Color purple;
    Color indigo;
    Color pink;
    Color defaultColor;



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

        purple = new Color(1.0f, 0.6f, 0.06f, 0.83f);
        indigo = new Color(1.0f, 0.18f, 0.13f, 0.62f);
        pink = new Color(1.0f, 0.88f, 0.60f, 0.82f);
        defaultColor = new Color(1.0f, 0.84f, 0.84f, 0.84f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DefaultButton()
    {
        theLevelManager.currentColor = "Default";
        theLevelManager.coinShopText.GetComponentInChildren<Text>().color = defaultColor;
        theLevelManager.towerSegmentToUse = theLevelManager.defaultTowerSegment;
        theLevelManager.ninjaStarToUse = theLevelManager.defaultNinjaStar;
    }

    public void RedButton()
    {
        if (canUseRed)
        {
            theLevelManager.currentColor = "Red";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = Color.red;
            theLevelManager.towerSegmentToUse = theLevelManager.redTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.redNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 5 && !canUseRed)
        {
            canUseRed = true;
            theLevelManager.currentColor = "Red";
                        theLevelManager.coinShopText.GetComponentInChildren<Text>().color = Color.red;
            theLevelManager.towerSegmentToUse = theLevelManager.redTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.redNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.redButton.GetComponentInChildren<Text>().text = "Red";
        }
    }

    public void GreenButton()
    {
        if (canUseGreen)
        {
            theLevelManager.currentColor = "Green";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = Color.green;
            theLevelManager.towerSegmentToUse = theLevelManager.greenTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.greenNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 5 && !canUseGreen)
        {
            canUseGreen = true;
            theLevelManager.currentColor = "Green";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = Color.green;
            theLevelManager.towerSegmentToUse = theLevelManager.greenTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.greenNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.greenButton.GetComponentInChildren<Text>().text = "Green";
        }
    }

    public void BlueButton()
    {
        if (canUseBlue)
        {
            theLevelManager.currentColor = "Blue";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = Color.blue;
            theLevelManager.towerSegmentToUse = theLevelManager.blueTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.blueNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 5 && !canUseBlue)
        {
            canUseBlue = true;
            theLevelManager.currentColor = "Blue";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = Color.blue;
            theLevelManager.towerSegmentToUse = theLevelManager.blueTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.blueNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.blueButton.GetComponentInChildren<Text>().text = "Blue";
        }
    }

    public void YellowButton()
    {
        if (canUseYellow)
        {
            theLevelManager.currentColor = "Yellow";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = Color.yellow;
            theLevelManager.towerSegmentToUse = theLevelManager.yellowTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.yellowNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 5 && !canUseYellow)
        {
            canUseYellow = true;
            theLevelManager.currentColor = "Yellow";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = Color.yellow;
            theLevelManager.towerSegmentToUse = theLevelManager.yellowTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.yellowNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.yellowButton.GetComponentInChildren<Text>().text = "Yellow";
        }
    }

    public void BlackButton()
    {
        if (canUseBlack)
        {
            theLevelManager.currentColor = "Black";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = Color.black;
            theLevelManager.towerSegmentToUse = theLevelManager.blackTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.blackNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 5 && !canUseBlack)
        {
            canUseBlack = true;
            theLevelManager.currentColor = "Black";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = Color.black;
            theLevelManager.towerSegmentToUse = theLevelManager.blackTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.blackNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.blackButton.GetComponentInChildren<Text>().text = "Black";
        }
    }

    public void PurpleButton()
    {
        if (canUsePurple)
        {
            theLevelManager.currentColor = "Purple";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = purple;
            theLevelManager.towerSegmentToUse = theLevelManager.purpleTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.purpleNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 5 && !canUsePurple)
        {
            canUsePurple = true;
            theLevelManager.currentColor = "Purple";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = purple;
            theLevelManager.towerSegmentToUse = theLevelManager.purpleTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.purpleNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.purpleButton.GetComponentInChildren<Text>().text = "Purple";
        }
    }

    public void IndigoButton()
    {
        if (canUseIndigo)
        {
            theLevelManager.currentColor = "Indigo";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = indigo;
            theLevelManager.towerSegmentToUse = theLevelManager.indigoTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.indigoNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 5 && !canUseIndigo)
        {
            canUseIndigo = true;
            theLevelManager.currentColor = "Indigo";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = indigo;
            theLevelManager.towerSegmentToUse = theLevelManager.indigoTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.indigoNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.indigoButton.GetComponentInChildren<Text>().text = "Indigo";
        }
    }

    public void PinkButton()
    {
        if (canUsePink)
        {
            theLevelManager.currentColor = "Pink";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = pink;
            theLevelManager.towerSegmentToUse = theLevelManager.pinkTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.pinkNinjaStar;
        }
        else if (theLevelManager.goldCoinCount >= 5 && !canUsePink)
        {
            canUsePink = true;
            theLevelManager.currentColor = "Pink";
            theLevelManager.coinShopText.GetComponentInChildren<Text>().color = pink;
            theLevelManager.towerSegmentToUse = theLevelManager.pinkTowerSegment;
            theLevelManager.ninjaStarToUse = theLevelManager.pinkNinjaStar;
            theLevelManager.goldCoinCount -= 5;
            theLevelManager.pinkButton.GetComponentInChildren<Text>().text = "Pink";
        }
    }
}
