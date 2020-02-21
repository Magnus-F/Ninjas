using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    float closest;
    float speed = 0.2f;
    Vector3 position;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D myCollider = GetComponent<BoxCollider2D>();

        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if(blocks.Length < 1)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this);
        }
        else
        {
            closest = myCollider.Distance(blocks[0].GetComponent<BoxCollider2D>()).distance;

            foreach (GameObject g in blocks)
            {
                if(myCollider.Distance(g.GetComponent<BoxCollider2D>()).distance < closest)
                {
                    closest = myCollider.Distance(g.GetComponent<BoxCollider2D>()).distance;
                    position = g.transform.position;
                }
            }
            direction = Vector3.Normalize(position - transform.position);
            
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<SpriteRenderer>().enabled)
        {
            Destroy(this);
        }
        transform.position = transform.position + (speed * direction);
    }
}
