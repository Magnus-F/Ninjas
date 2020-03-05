using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float ninjaStarCount;
    public float ninjaStarValue;
    public Text ninjaStarText;

    public float goldCoinCount;
    public float goldCoinValue;
    public Text goldCoinText;

    public Text towerHeightText;
    public Text currentColorText;
    public string currentColor;

    public bool canBuildTower;
    public bool canBuildDefense;

    public GameObject pirateShip;
    public Transform leftPoint1;
    public Transform rightPoint1;
    public Transform leftPoint2;
    public Transform rightPoint2;
    public Transform leftPoint3;
    public Transform rightPoint3;
    public Transform leftPoint4;
    public Transform rightPoint4;
    public Transform leftPoint5;
    public Transform rightPoint5;
    public Transform leftPoint6;
    public Transform rightPoint6;
    public Transform leftPoint7;
    public Transform rightPoint7;
    public Transform leftPoint8;
    public Transform rightPoint8;

    public float pirateTime;
    private Transform spawnPosition;
    public SpriteRenderer theShipSprite;
    public Button newFloorButton;
    public Button newDefenseButton;

    // tower segments
    public GameObject towerSegmentToUse;
    public GameObject defaultTowerSegment;
    public GameObject redTowerSegment;
    public GameObject yellowTowerSegment;
    public GameObject blueTowerSegment;
    public GameObject greenTowerSegment;
    public GameObject blackTowerSegment;
    public GameObject purpleTowerSegment;
    public GameObject pinkTowerSegment;
    public GameObject indigoTowerSegment;

    // attack tower segments
    public GameObject newAttackTowerSegment;

    public GameObject ninjaStarToUse;
    public GameObject defaultNinjaStar;
    public GameObject redNinjaStar;
    public GameObject greenNinjaStar;
    public GameObject blueNinjaStar;
    public GameObject yellowNinjaStar;
    public GameObject blackNinjaStar;
    public GameObject purpleNinjaStar;
    public GameObject indigoNinjaStar;
    public GameObject pinkNinjaStar;

    public GameObject redButton;
    public GameObject greenButton;
    public GameObject blueButton;
    public GameObject yellowButton;
    public GameObject blackButton;
    public GameObject purpleButton;
    public GameObject indigoButton;
    public GameObject pinkButton;

    public GameObject attackTowerSegment;
    public int towerHeight;
    public int towerSegments;
    bool attackTower = false;
    public int towerCost;

    public GoldBlockScript theGoldBlockScript;

    public Button pauseButton;
    public Button playButton;
    public GameObject thePauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        ninjaStarCount = 0;
        ninjaStarValue = 1;

        goldCoinCount = 5;
        goldCoinValue = 1;

        //newFloorButton.gameObject.SetActive(false);
        theGoldBlockScript = FindObjectOfType<GoldBlockScript>();
        towerHeight = 0;
        towerSegments = 0;
        towerCost = 0;
        pirateTime = 5;

        towerSegmentToUse = defaultTowerSegment;
        ninjaStarToUse = defaultNinjaStar;

        canBuildTower = false;
        canBuildDefense = false;

        //playButton.gameObject.SetActive(false);
        thePauseScreen.SetActive(false);
        currentColor = "Default";

        StartCoroutine(NinjaStarTime());
        StartCoroutine(PirateTime());
    }

    // Update is called once per frame
    void Update()
    {
        if(ninjaStarCount < 10+towerCost)
        {
            newFloorButton.GetComponentInChildren<Text>().text = "Ninja Stars Needed: " + ((10 + towerCost)-ninjaStarCount);
            canBuildTower = false;
        }
        else if (ninjaStarCount >= 10 + towerCost)
        {
            newFloorButton.GetComponentInChildren<Text>().text = "Add New Floor!";
            canBuildTower = true;
        }
        if (goldCoinCount < 5)
        {
            newDefenseButton.GetComponentInChildren<Text>().text = "Gold Coins Needed: " + (5 - goldCoinCount);
            canBuildDefense = false;
        }
        else if (goldCoinCount >= 5)
        {
            newDefenseButton.GetComponentInChildren<Text>().text = "Add New Defense!";
            canBuildDefense = true;
        }

        ninjaStarText.text = "Ninja Stars: " + ninjaStarCount;
        goldCoinText.text = "Gold Coins: " + goldCoinCount;
        towerHeightText.text = "Tower Height: " + towerHeight;
        currentColorText.text = "Current Color: " + currentColor;
        ninjaStarValue = towerSegments * 1f;

        /*if(ninjaStarCount >= 10+towerCost)
        {
            newFloorButton.gameObject.SetActive(true);
        }
        else
        {
            newFloorButton.gameObject.SetActive(false);
        }*/

        //newFloorButton.onClick.AddListener(TaskOnClick);
        towerCost = 10 * towerSegments;

        if(Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            //use horizontal stuff
        }
        else if(Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            //useverticalstuff
            goldCoinCount += 1;
        }
    }

    IEnumerator NinjaStarTime()
    {
        while (true)
        {
            ninjaStarCount = ninjaStarCount + ninjaStarValue + 1;
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator PirateTime()
    {
        while (true)
        {
            ChooseSpawn();
            GameObject cloneShip = (GameObject)Instantiate(pirateShip, new Vector3(spawnPosition.position.x, spawnPosition.position.y, 0.0f), Quaternion.Euler(new Vector3(0, 0, 0)));
            yield return new WaitForSeconds(pirateTime);
        }
    }

    void ChooseSpawn()
    {
        // starting floor
        if(towerHeight == 0)
        {
            int spawnNum = Random.Range(1, 3);
            if (spawnNum == 1)
            {
                spawnPosition = leftPoint1;
            }
            else
            {
                spawnPosition = rightPoint1;
            }
            pirateTime = 5;
        }

        // tower has been built once
        else if (towerHeight == 1)
        {
            int spawnNum = Random.Range(1, 5);
            if (spawnNum == 1)
            {
                spawnPosition = leftPoint1;
            }
            else if (spawnNum == 2)
            {
                spawnPosition = rightPoint1;
            }
            else if (spawnNum == 3)
            {
                spawnPosition = leftPoint2;
            }
            else if (spawnNum == 4)
            {
                spawnPosition = rightPoint2;
            }
            pirateTime = 4.5f;
        }

        // tower has been built twice
        else if (towerHeight == 2)
        {
            int spawnNum = Random.Range(1, 7);
            if (spawnNum == 1)
            {
                spawnPosition = leftPoint1;
            }
            else if (spawnNum == 2)
            {
                spawnPosition = rightPoint1;
            }
            else if (spawnNum == 3)
            {
                spawnPosition = leftPoint2;
            }
            else if (spawnNum == 4)
            {
                spawnPosition = rightPoint2;
            }
            else if (spawnNum == 5)
            {
                spawnPosition = leftPoint3;
            }
            else if (spawnNum == 6)
            {
                spawnPosition = rightPoint3;
            }
            pirateTime = 4f;
        }
        // tower has been built three times
        else if (towerHeight == 3)
        {
            int spawnNum = Random.Range(1, 9);
            if (spawnNum == 1)
            {
                spawnPosition = leftPoint1;
            }
            else if (spawnNum == 2)
            {
                spawnPosition = rightPoint1;
            }
            else if (spawnNum == 3)
            {
                spawnPosition = leftPoint2;
            }
            else if (spawnNum == 4)
            {
                spawnPosition = rightPoint2;
            }
            else if (spawnNum == 5)
            {
                spawnPosition = leftPoint3;
            }
            else if (spawnNum == 6)
            {
                spawnPosition = rightPoint3;
            }
            else if (spawnNum == 7)
            {
                spawnPosition = leftPoint4;
            }
            else if (spawnNum == 8)
            {
                spawnPosition = rightPoint4;
            }
            pirateTime = 3.5f;
        }

        // tower has been built four times
        else if (towerHeight == 4)
        {
            int spawnNum = Random.Range(1, 11);
            if (spawnNum == 1)
            {
                spawnPosition = leftPoint1;
            }
            else if (spawnNum == 2)
            {
                spawnPosition = rightPoint1;
            }
            else if (spawnNum == 3)
            {
                spawnPosition = leftPoint2;
            }
            else if (spawnNum == 4)
            {
                spawnPosition = rightPoint2;
            }
            else if (spawnNum == 5)
            {
                spawnPosition = leftPoint3;
            }
            else if (spawnNum == 6)
            {
                spawnPosition = rightPoint3;
            }
            else if (spawnNum == 7)
            {
                spawnPosition = leftPoint4;
            }
            else if (spawnNum == 8)
            {
                spawnPosition = rightPoint4;
            }
            else if (spawnNum == 9)
            {
                spawnPosition = leftPoint5;
            }
            else if (spawnNum == 10)
            {
                spawnPosition = rightPoint5;
            }
            pirateTime = 3f;
        }

        // tower has been built five times
        else if (towerHeight == 5)
        {
            int spawnNum = Random.Range(1, 13);
            if (spawnNum == 1)
            {
                spawnPosition = leftPoint1;
            }
            else if (spawnNum == 2)
            {
                spawnPosition = rightPoint1;
            }
            else if (spawnNum == 3)
            {
                spawnPosition = leftPoint2;
            }
            else if (spawnNum == 4)
            {
                spawnPosition = rightPoint2;
            }
            else if (spawnNum == 5)
            {
                spawnPosition = leftPoint3;
            }
            else if (spawnNum == 6)
            {
                spawnPosition = rightPoint3;
            }
            else if (spawnNum == 7)
            {
                spawnPosition = leftPoint4;
            }
            else if (spawnNum == 8)
            {
                spawnPosition = rightPoint4;
            }
            else if (spawnNum == 9)
            {
                spawnPosition = leftPoint5;
            }
            else if (spawnNum == 10)
            {
                spawnPosition = rightPoint5;
            }
            else if (spawnNum == 11)
            {
                spawnPosition = leftPoint6;
            }
            else if (spawnNum == 12)
            {
                spawnPosition = rightPoint6;
            }
            pirateTime = 2.5f;
        }

        // tower has been built six times
        else if (towerHeight == 6)
        {
            int spawnNum = Random.Range(1, 15);
            if (spawnNum == 1)
            {
                spawnPosition = leftPoint1;
            }
            else if (spawnNum == 2)
            {
                spawnPosition = rightPoint1;
            }
            else if (spawnNum == 3)
            {
                spawnPosition = leftPoint2;
            }
            else if (spawnNum == 4)
            {
                spawnPosition = rightPoint2;
            }
            else if (spawnNum == 5)
            {
                spawnPosition = leftPoint3;
            }
            else if (spawnNum == 6)
            {
                spawnPosition = rightPoint3;
            }
            else if (spawnNum == 7)
            {
                spawnPosition = leftPoint4;
            }
            else if (spawnNum == 8)
            {
                spawnPosition = rightPoint4;
            }
            else if (spawnNum == 9)
            {
                spawnPosition = leftPoint5;
            }
            else if (spawnNum == 10)
            {
                spawnPosition = rightPoint5;
            }
            else if (spawnNum == 11)
            {
                spawnPosition = leftPoint6;
            }
            else if (spawnNum == 12)
            {
                spawnPosition = rightPoint6;
            }
            else if (spawnNum == 13)
            {
                spawnPosition = leftPoint7;
            }
            else if (spawnNum == 14)
            {
                spawnPosition = rightPoint7;
            }
            pirateTime = 2f;
        }

        // tower is higher
        else
        {
            int spawnNum = Random.Range(1, 17);
            if (spawnNum == 1)
            {
                spawnPosition = leftPoint1;
            }
            else if (spawnNum == 2)
            {
                spawnPosition = rightPoint1;
            }
            else if (spawnNum == 3)
            {
                spawnPosition = leftPoint2;
            }
            else if (spawnNum == 4)
            {
                spawnPosition = rightPoint2;
            }
            else if (spawnNum == 5)
            {
                spawnPosition = leftPoint3;
            }
            else if (spawnNum == 6)
            {
                spawnPosition = rightPoint3;
            }
            else if (spawnNum == 7)
            {
                spawnPosition = leftPoint4;
            }
            else if (spawnNum == 8)
            {
                spawnPosition = rightPoint4;
            }
            else if (spawnNum == 9)
            {
                spawnPosition = leftPoint5;
            }
            else if (spawnNum == 10)
            {
                spawnPosition = rightPoint5;
            }
            else if (spawnNum == 11)
            {
                spawnPosition = leftPoint6;
            }
            else if (spawnNum == 12)
            {
                spawnPosition = rightPoint6;
            }
            else if (spawnNum == 13)
            {
                spawnPosition = leftPoint7;
            }
            else if (spawnNum == 14)
            {
                spawnPosition = rightPoint7;
            }
            else if (spawnNum == 15)
            {
                spawnPosition = leftPoint8;
            }
            else if (spawnNum == 16)
            {
                spawnPosition = rightPoint8;
            }
            pirateTime = 1.5f;
        }
    }

    public void FlashRed(SpriteRenderer objectToHurt)
    {
        objectToHurt.color = Color.red;

        StartCoroutine(ExecuteAfterTime(objectToHurt));
    }

    public void ResetColor(SpriteRenderer objectToHurt)
    {
        if (objectToHurt != null)
        {
            objectToHurt.color = theShipSprite.color;
        }
    }

    IEnumerator ExecuteAfterTime(SpriteRenderer objectToAffect)
    {
        yield return new WaitForSeconds(0.25f);
        ResetColor(objectToAffect);
    }

    public void TaskOnClick()
    {
        if(canBuildTower)
        {
            if (attackTower)
            {
                Instantiate(attackTowerSegment, new Vector3(theGoldBlockScript.goldBlockPosition.position.x, towerHeight, 0f), Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                Instantiate(towerSegmentToUse, new Vector3(theGoldBlockScript.goldBlockPosition.position.x, towerHeight, 0f), Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            towerHeight += 1;
            towerSegments += 1;
            ninjaStarCount -= 10 + towerCost;
        }
    }

    public void TaskOnClick2()
    {
        if(canBuildDefense)
        {
            if (attackTower)
            {
                Instantiate(attackTowerSegment, new Vector3(theGoldBlockScript.goldBlockPosition.position.x, towerHeight, 0f), Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                Instantiate(newAttackTowerSegment, new Vector3(theGoldBlockScript.goldBlockPosition.position.x, towerHeight, 0f), Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            towerHeight += 1;
            goldCoinCount -= 5;
        }
    }

    //sets bool to true/false
    public void towerSwitch()
    {
        attackTower = !attackTower;
    }

    // pauses game
    public void PauseGame()
    {
        Time.timeScale = 0;
        playButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        thePauseScreen.SetActive(true);

        //thePauseScreen.SetActive(true);
        //thePlayer.canMove = false;
    }

    public void ResumeGame()
    {
        //thePauseScreen.SetActive(false);
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        thePauseScreen.SetActive(false);

        Time.timeScale = 1f;
        //thePlayer.canMove = true;
    }
}
