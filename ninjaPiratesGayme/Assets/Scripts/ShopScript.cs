using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public LevelManager theLevelManager;

    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
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
        theLevelManager.currentColor = "Red";
        theLevelManager.towerSegmentToUse = theLevelManager.redTowerSegment;
        theLevelManager.ninjaStarToUse = theLevelManager.redNinjaStar;
    }

    public void GreenButton()
    {
        theLevelManager.currentColor = "Green";
        theLevelManager.towerSegmentToUse = theLevelManager.greenTowerSegment;
        theLevelManager.ninjaStarToUse = theLevelManager.greenNinjaStar;
    }

    public void BlueButton()
    {
        theLevelManager.currentColor = "Blue";
        theLevelManager.towerSegmentToUse = theLevelManager.blueTowerSegment;
        theLevelManager.ninjaStarToUse = theLevelManager.blueNinjaStar;
    }

    public void YellowButton()
    {
        theLevelManager.currentColor = "Yellow";
        theLevelManager.towerSegmentToUse = theLevelManager.yellowTowerSegment;
        theLevelManager.ninjaStarToUse = theLevelManager.yellowNinjaStar;
    }

    public void BlackButton()
    {
        theLevelManager.currentColor = "Black";
        theLevelManager.towerSegmentToUse = theLevelManager.blackTowerSegment;
        theLevelManager.ninjaStarToUse = theLevelManager.blackNinjaStar;
    }

    public void PurpleButton()
    {
        theLevelManager.currentColor = "Purple";
        theLevelManager.towerSegmentToUse = theLevelManager.purpleTowerSegment;
        theLevelManager.ninjaStarToUse = theLevelManager.purpleNinjaStar;
    }

    public void IndigoButton()
    {
        theLevelManager.currentColor = "Indigo";
        theLevelManager.towerSegmentToUse = theLevelManager.indigoTowerSegment;
        theLevelManager.ninjaStarToUse = theLevelManager.indigoNinjaStar;
    }

    public void PinkButton()
    {
        theLevelManager.currentColor = "Pink";
        theLevelManager.towerSegmentToUse = theLevelManager.pinkTowerSegment;
        theLevelManager.ninjaStarToUse = theLevelManager.pinkNinjaStar;
    }
}
