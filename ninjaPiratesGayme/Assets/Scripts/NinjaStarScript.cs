using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarScript : MonoBehaviour
{
    public EnemyShipScript theEnemyShipScript;
    public LevelManager theLevelManager;

    Vector3 direction;
    

    float speed = 0.05f;


    public void SetDirection(Vector3 dir)
    {
        direction = Vector3.Normalize(dir);
    }


    // Start is called before the first frame update
    void Start()
    {
        theEnemyShipScript = FindObjectOfType<EnemyShipScript>();
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temppos = transform.position;
        temppos += direction * speed;
        transform.position = temppos;

        Destroy(this.gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            theEnemyShipScript.HurtEnemyMethod(collision.GetComponent<EnemyShipScript>(), 0.5f);
            Destroy(gameObject);

            /*if (collision.GetComponent<EnemyShipScript>().enemyHealth > 0)
            {
                theLevelManager.FlashRed(collision.GetComponent<SpriteRenderer>());
            }*/
        }
        else if(collision.tag == "Coin")
        {
            Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else if (collision.tag == "Ground")
        {
            //Physics2D.IgnoreCollision(collision.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
