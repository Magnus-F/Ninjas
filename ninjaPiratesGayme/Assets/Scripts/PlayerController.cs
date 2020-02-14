using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;

    public GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                GameObject obj = Instantiate(block, new Vector3(hit.point.x, hit.point.y, 0), Quaternion.identity) as GameObject;
            }
        }
    }
}
