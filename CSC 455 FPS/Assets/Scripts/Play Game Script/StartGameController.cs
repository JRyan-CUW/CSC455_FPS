using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameController : MonoBehaviour {
    public static bool startTimer = false;
    public static bool failed = false;
    public static int targetsHit = 0;
    public static bool gameWon = false;
    public GameObject[] targetAr;

    private GameObject monster;
    private Camera mainCam;
    private bool gameStarted = false;
    private bool beastCanBeKilled = false;
    
    // Use this for initialization
    void Start()
    {
        mainCam = transform.Find("FPS View").Find("FPS Camera").GetComponent<Camera>();
        monster = GameObject.FindGameObjectWithTag("Monster");
        targetAr = GameObject.FindGameObjectsWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        if (targetsHit == 5)
        {
            gameWon = true;
            startTimer = false;
            targetsHit = 0;
            gameStarted = false;
            Timer.timeLeft = 30f;
            CompletedStages.stagesCompleted++;
            if (CompletedStages.stagesCompleted < 4)
            {
                Timer.counterText.text = "You won this round";
            }
            else
            {
                Timer.counterText.text = "Kill The Beast!";
                beastCanBeKilled = true;
            }
        }
        if (failed)
        {
            failed = false;
            foreach (GameObject target in targetAr)
            {
                target.gameObject.SetActive(true);
            }
            Timer.counterText.text = "Failed: try again";
            startTimer = false;
            targetsHit = 0;
            gameStarted = false;
            Timer.timeLeft = 30f;
            
        }
        else if(gameStarted)
        {
            DetectHit();
        }
        else if (gameStarted == false)
        {
            StartGame();
        }
        if (beastCanBeKilled)
        {
            KillBeast();
        }
    }

    void StartGame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
            {
                if (hit.transform.tag == "StartGame")
                {
                    startTimer = true;
                    gameStarted = true;
                }
            }
        }
    }

    void DetectHit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
            {
                if (hit.transform.tag == "Target")
                {
                    hit.transform.gameObject.SetActive(false);
                    //Destroy(hit.transform.gameObject);
                    targetsHit++;
                    Timer.timeLeft += 5;
                }
            }
        }
    }

    void KillBeast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
            {
                if (hit.transform.tag == "Monster")
                {
                    Destroy(hit.transform.gameObject);
                    Timer.counterText.text = "You Won!";
                }
            }
        }
    }
}
