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

    public GameObject attackTowerSegment;
    public int towerHeight;
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
        towerCost = 0;

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
        ninjaStarValue = towerHeight * 1f;

        /*if(ninjaStarCount >= 10+towerCost)
        {
            newFloorButton.gameObject.SetActive(true);
        }
        else
        {
            newFloorButton.gameObject.SetActive(false);
        }*/

        //newFloorButton.onClick.AddListener(TaskOnClick);
        towerCost = 10 * towerHeight;
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
            GameObject cloneShip = (GameObject)Instantiate(pirateShip, new Vector3(spawnPosition.position.x, spawnPosition.position.y, 0f), Quaternion.Euler(new Vector3(0, 0, 0)));
            yield return new WaitForSeconds(5);
        }
    }

    void ChooseSpawn()
    {
        int spawnNum = Random.Range(1, 3);

        if(spawnNum == 1)
        {
            spawnPosition = leftPoint1;
        }
        else
        {
            spawnPosition = rightPoint1;
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
