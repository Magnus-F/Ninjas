using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldBlockScript : MonoBehaviour
{
    public GameObject ninjaStar;
    public LevelManager myLevelManager;
    public Transform goldBlockPosition;

    // Start is called before the first frame update
    void Start()
    {
        myLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && myLevelManager.ninjaStarCount > 0)
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            GameObject projectile = (GameObject)Instantiate(ninjaStar, myPos, rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * 10f;
            myLevelManager.ninjaStarCount -= 1;
        }
    }
}
