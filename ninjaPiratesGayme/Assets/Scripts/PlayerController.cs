using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;

    public GameObject OBlock;
    public GameObject IBlock;

    GameObject selectedBlock;
    GameObject ghostBlock;
    GameObject[] blocks;

    // Start is called before the first frame update
    void Start()
    {
        selectedBlock = OBlock;
        ghostBlock = Instantiate(selectedBlock, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        Destroy(ghostBlock.GetComponent<Rigidbody2D>());
        ghostBlock.GetComponent<BoxCollider2D>().enabled = false;
        ghostBlock.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .0f);
        ghostBlock.tag = "Untagged";

    }

    // Update is called once per frame
    void Update()
    {
        bool placable = true;
        if (Input.GetMouseButtonDown(0))
        {
            blocks = GameObject.FindGameObjectsWithTag("Block");
        }



        ghostBlock.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .0f);
        if (Input.GetMouseButton(0))
        {
            ghostBlock.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .25f);
            Vector3 ghostpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ghostpos.z = 0;
            ghostBlock.transform.position = ghostpos;

            

        }
        

        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            selectedBlock = OBlock;
            Destroy(ghostBlock);
            ghostBlock = Instantiate(selectedBlock, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            ghostBlock.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(ghostBlock.GetComponent<BoxCollider2D>());
            ghostBlock.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .0f);
            ghostBlock.tag = "Untagged";
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            selectedBlock = IBlock;
            Destroy(ghostBlock);
            ghostBlock = Instantiate(selectedBlock, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            ghostBlock.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(ghostBlock.GetComponent<BoxCollider2D>());
            ghostBlock.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .0f);
            ghostBlock.tag = "Untagged";
        }


        if (Input.GetMouseButtonUp(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            if(placable)Instantiate(selectedBlock, pos, Quaternion.identity);
        }
    }
}
