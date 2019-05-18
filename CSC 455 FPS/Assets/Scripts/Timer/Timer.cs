using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public static Text counterText;

    public static float timeLeft = 30.0f;

	// Use this for initialization
	void Start () {
        counterText = GetComponent<Text>() as Text;
	}
	
	// Update is called once per frame
	void Update () {
        if(StartGameController.startTimer)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft > 0)
            {
                counterText.text = "Time Left: " + Mathf.Round(timeLeft);
            }
            else
            {
                StartGameController.failed = true;
            }
        }
    }
}
