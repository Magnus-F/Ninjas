using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarScript : MonoBehaviour
{
    public EnemyShipScript theEnemyShipScript;
    public LevelManager theLevelManager;

    // Start is called before the first frame update
    void Start()
    {
        theEnemyShipScript = FindObjectOfType<EnemyShipScript>();
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            theEnemyShipScript.HurtEnemyMethod(collision.GetComponent<EnemyShipScript>(), 1f);

            /*if (collision.GetComponent<EnemyShipScript>().enemyHealth > 0)
            {
                theLevelManager.FlashRed(collision.GetComponent<SpriteRenderer>());
            }*/
        }

        Destroy(gameObject);
    }
}
