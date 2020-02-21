using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float ninjaStarCount;
    public float ninjaStarValue;
    public Text ninjaStarText;

    // Start is called before the first frame update
    void Start()
    {
        ninjaStarCount = 0;
        ninjaStarValue = 1;

        StartCoroutine(NinjaStarTime());
    }

    // Update is called once per frame
    void Update()
    {
        ninjaStarText.text = "Ninja Stars: " + ninjaStarCount.ToString();
    }

    IEnumerator NinjaStarTime()
    {
        while (true)
        {
            ninjaStarCount = ninjaStarCount + ninjaStarValue;
            yield return new WaitForSeconds(1);
        }
    }
}
