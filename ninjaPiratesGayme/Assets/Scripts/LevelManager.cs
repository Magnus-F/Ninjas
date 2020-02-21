using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float ninjaStarCount;
    public float ninjaStarValue;
    public Text ninjaStarText;
    public GameObject pirateShip;
    public Transform leftPoint1;
    public Transform rightPoint1;
    private Transform spawnPosition;
    public SpriteRenderer theShipSprite;
    public Button newFloorButton;
    public GameObject towerSegment;
    public int towerHeight;

    public GoldBlockScript theGoldBlockScript;

    // Start is called before the first frame update
    void Start()
    {
        ninjaStarCount = 0;
        ninjaStarValue = 1;
        newFloorButton.gameObject.SetActive(false);
        theGoldBlockScript = FindObjectOfType<GoldBlockScript>();
        towerHeight = 1;

        StartCoroutine(NinjaStarTime());
        StartCoroutine(PirateTime());
    }

    // Update is called once per frame
    void Update()
    {
        ninjaStarText.text = "Ninja Stars: " + ninjaStarCount;
        //Debug.Log(ninjaStarCount);

        if(ninjaStarCount >= 10)
        {
            newFloorButton.gameObject.SetActive(true);
        }
        else
        {
            newFloorButton.gameObject.SetActive(false);
        }

        //newFloorButton.onClick.AddListener(TaskOnClick);
        
    }

    IEnumerator NinjaStarTime()
    {
        while (true)
        {
            ninjaStarCount = ninjaStarCount + ninjaStarValue;
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
        Debug.Log("You have clicked the button!");
        Instantiate(towerSegment, new Vector3(theGoldBlockScript.goldBlockPosition.position.x + 2, towerHeight, 0f), Quaternion.Euler(new Vector3(0, 0, 0)));
        towerHeight += 1;
        ninjaStarCount -= 10;
    }
}
