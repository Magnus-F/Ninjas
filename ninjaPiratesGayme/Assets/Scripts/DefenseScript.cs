using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseScript : MonoBehaviour
{
    public GameObject theCannon;
    public Rigidbody2D theCannonRB;
    public float cannonTimer;
    public LevelManager myLevelManager;
    public bool canShoot;
    public float projectilespeed;
    float verticalrange;

    // Start is called before the first frame update
    void Start()
    {
        cannonTimer = 0;
        myLevelManager = FindObjectOfType<LevelManager>();
        canShoot = false;


        verticalrange = 2.0f; // decides the verticle range of the turret's aiming
        projectilespeed = 0.5f; //decides the speed of the ninja star
    }

    // Update is called once per frame
    void Update()
    {
        if(cannonTimer < 2)
        {
            canShoot = true;
        }
        else if(cannonTimer > 2 && canShoot)//myLevelManager.ninjaStarCount > 0)
        {
            

            GameObject[] pirates = GameObject.FindGameObjectsWithTag("Enemy");

            GameObject closestrightpirate = new GameObject();
            GameObject closestleftpirate = new GameObject();

            float crpd = 10000.0f;
            float clpd = 10000.0f;

            

            foreach(GameObject e in pirates)
            {
                if (e.transform.position.y < transform.position.y + verticalrange && e.transform.position.y > transform.position.y - verticalrange)
                {
                    if (e.transform.position.x > transform.position.x)
                    {
                        if(Vector2.Distance(e.transform.position,transform.position) < crpd)
                        {
                            crpd = Vector2.Distance(e.transform.position, transform.position);
                            closestrightpirate = e;
                        }
                        
                    }
                    else
                    {
                        if (Vector2.Distance(e.transform.position, transform.position) < clpd)
                        {
                            clpd = Vector2.Distance(e.transform.position, transform.position);
                            closestleftpirate = e;

                        }
                    }
                }
                
            }

            if (closestrightpirate.tag == "Enemy") {
                GameObject projectile2 = Instantiate(myLevelManager.ninjaStarToUse, new Vector3(this.transform.position.x + 2, this.transform.position.y, this.transform.position.z), this.transform.rotation);
                Vector3 spd = closestleftpirate.transform.position - transform.position;
                spd = Vector3.Normalize(spd) * projectilespeed;
                projectile2.GetComponent<Rigidbody2D>().velocity = spd;
            }

            if(closestleftpirate.tag == "Enemy")
            {
                GameObject projectile1 = Instantiate(myLevelManager.ninjaStarToUse, new Vector3(this.transform.position.x - 2, this.transform.position.y, this.transform.position.z), this.transform.rotation);
                Vector3 spd = closestrightpirate.transform.position - transform.position;
                spd = Vector3.Normalize(spd) * projectilespeed;
                projectile1.GetComponent<Rigidbody2D>().velocity = spd;
            }


            



            //Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            //Vector2 myPos = new Vector2(theCannon.transform.position.x, theCannon.transform.position.y);
            //Vector2 direction = target - myPos;
            //direction.Normalize();
            //Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            //GameObject projectile = (GameObject)Instantiate(myLevelManager.ninjaStarToUse, myPos, this.transform.rotation);
            //projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(10f, 0);
            //myLevelManager.ninjaStarCount -= 1;
            Debug.Log("fire");
            canShoot = false;
        }
        else
        {
            cannonTimer = 0;
        }

        cannonTimer += Time.deltaTime;

        
    }
}
