using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private Text timeElapsed;
    [SerializeField] GameObject largeBrick;
    [SerializeField] GameObject smallBrick;
    [SerializeField] GameObject mediumBrick;

    float smallBrickTimer = 2f;
    float mediumBrickTimer = 3f;
    float largeBrickTimer = 5f;

    float elapsedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        timeElapsed = GameObject.Find("Time Alive").GetComponent<Text>();
        timeElapsed.text = "Time Alive: " + elapsedTime.ToString("F2") + " Secs";


        smallBrickTimer -= Time.deltaTime;
        mediumBrickTimer -= Time.deltaTime;
        largeBrickTimer -= Time.deltaTime;

        if (smallBrickTimer <= 0f)
        {
            Instantiate(smallBrick, new Vector2(10f, -2.96f), transform.rotation);
            smallBrickTimer = 2f;
        }

        else if (mediumBrickTimer <= 0f)
        {
            Instantiate(mediumBrick, new Vector2(3f, 0.5f), transform.rotation);
            mediumBrickTimer = 3f;
        }

        else if (largeBrickTimer <= 0f)
        {
            Instantiate(largeBrick, new Vector2(12f, 3f), transform.rotation);
            largeBrickTimer = 5f;
        }
    }

    public void Reset()
    {
        elapsedTime = 0f;
    }
}