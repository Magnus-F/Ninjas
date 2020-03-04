using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipScript : MonoBehaviour
{
    public float moveSpeed;
    public float speed;

    public float enemyHealth;
    private float maxEnemyHealth;
    public GameObject goldBlock;

    // rigidbody and player objects
    public Rigidbody2D theShipRB;
    public GameObject theShip;
    public LevelManager myLevelManager;
    public GameObject goldCoin;

    // Start is called before the first frame update
    void Start()
    {
        theShipRB = GetComponent<Rigidbody2D>();
        maxEnemyHealth = 2;
        enemyHealth = maxEnemyHealth;
        moveSpeed = 1;
        goldBlock = GameObject.FindGameObjectWithTag("GoldBlock");
        myLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temppos = transform.position;
        temppos.z = 0.0f;
        transform.position = temppos;
        if (theShip.transform.position.x > goldBlock.transform.position.x)
        {
            speed = -moveSpeed;
            theShipRB.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            speed = moveSpeed;
            theShipRB.transform.localScale = new Vector3(1, 1, 1);
        }

        if (enemyHealth <= 0)
        {
            Destroy(theShip);
            myLevelManager.goldCoinCount += 1;
            Instantiate(goldCoin, theShipRB.transform.position, theShip.transform.rotation);
        }

        theShipRB.velocity = new Vector3(speed, 0f, 0f);
    }

    public void HurtEnemyMethod(EnemyShipScript objectToHurt, float damageToTake)
    {
        objectToHurt.enemyHealth -= damageToTake;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tower")
        {
            myLevelManager.ninjaStarCount = 0;

            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 myPos = new Vector2(goldBlock.transform.position.x, goldBlock.transform.position.y);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        GameObject projectile = (GameObject)Instantiate(myLevelManager.ninjaStarToUse, myPos, rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 10f;
        myLevelManager.ninjaStarCount -= 1;
    }
}
