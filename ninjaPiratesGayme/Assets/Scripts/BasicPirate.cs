using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPirate : MonoBehaviour
{

    Vector3[] positions = new Vector3[4];

    public float speed;

    Vector3 currstartpoint;
    Vector3 currfinpoint;

    int place;

    float shootInterval;

    public GameObject CannonBall;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            positions[i] = new Vector3(Random.Range(-12, 12), Random.Range(-6, 6),0); 
        }

        transform.position = positions[0];
        currstartpoint = positions[0];
        currfinpoint = positions[1];

        place = 0;

        shootInterval = 5;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.Normalize(currfinpoint - currstartpoint);
        Vector3 tempPosition = transform.position + (direction * speed);
        transform.position = tempPosition;

        if (GetComponent<BoxCollider2D>().OverlapPoint(currfinpoint))
        {
            if(place < 3)
            {
                place++;
                currstartpoint = currfinpoint;
                currfinpoint = positions[place];
            }
            else
            {
                currstartpoint = positions[3];
                currfinpoint = positions[0];
                place = 0;
            }
        }



        if(shootInterval <= 0)
        {
            Destroy(Instantiate(CannonBall, transform.position, Quaternion.identity),3);
            shootInterval = 5;
        }
        else
        {
            shootInterval -= 0.1f;
        }


    }
}
