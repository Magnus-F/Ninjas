using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    float closest;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if(blocks.Length <= 0)
        {
            Destroy(this);
        }
        else
        {
            foreach (GameObject g in blocks)
            {

            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
