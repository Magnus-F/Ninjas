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

    bool placable
        ;

    // Start is called before the first frame update
    void Start()
    {
        selectedBlock = OBlock;
        ghostBlock = Instantiate(selectedBlock, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        Destroy(ghostBlock.GetComponent<Rigidbody2D>());
        ghostBlock.GetComponent<BoxCollider2D>().isTrigger = true;
        ghostBlock.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .0f);
        ghostBlock.tag = "Untagged";
        placable = true;
    }

    // Update is called once per frame
    void Update()
    {

        ghostBlock.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .0f);
        if (Input.GetMouseButton(0))
        {
            //makes ghostblock visible
            ghostBlock.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .25f);
            
            //makes ghostblock follow mouse
            Vector3 ghostpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ghostpos.z = 0;
            ghostBlock.transform.position = ghostpos;

            //gets all blocks in scene
            blocks = GameObject.FindGameObjectsWithTag("Block");

            placable = true;

            foreach(GameObject g in blocks)
            {
                //checks if ghostblock is overlapping any blocks in scene. If yes, then sets placable to false
                if (ghostBlock.GetComponent<BoxCollider2D>().IsTouching(g.GetComponent<BoxCollider2D>()))
                {
                    placable = false;
                    ghostBlock.GetComponent<SpriteRenderer>().color = new Color(1f, .25f, .25f, .25f);
                }
            }
        }
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedBlock = OBlock;
            Destroy(ghostBlock);
            ghostBlock = Instantiate(selectedBlock, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            ghostBlock.GetComponent<BoxCollider2D>().isTrigger = true;
            Destroy(ghostBlock.GetComponent<BoxCollider2D>());
            ghostBlock.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .0f);
            ghostBlock.tag = "Untagged";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            selectedBlock = IBlock;
            Destroy(ghostBlock);
            ghostBlock = Instantiate(selectedBlock, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            ghostBlock.GetComponent<BoxCollider2D>().isTrigger = true;
            Destroy(ghostBlock.GetComponent<BoxCollider2D>());
            ghostBlock.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .0f);
            ghostBlock.tag = "Untagged";
        }


        if (Input.GetMouseButtonUp(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            if (placable)
            { 
                Instantiate(selectedBlock, pos, Quaternion.identity); 
            }

            placable = true;
        }
    }
}
