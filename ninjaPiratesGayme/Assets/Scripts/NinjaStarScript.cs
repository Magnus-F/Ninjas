using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStarScript : MonoBehaviour
{
    public EnemyShipScript theEnemyShipScript;

    // Start is called before the first frame update
    void Start()
    {
        theEnemyShipScript = FindObjectOfType<EnemyShipScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        theEnemyShipScript.HurtEnemyMethod(1f);
    }
}
