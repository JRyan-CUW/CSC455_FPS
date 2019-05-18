using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompletedStages : MonoBehaviour
{

    public static Text stageText;

    public static int stagesCompleted = 0;

    // Use this for initialization
    void Start()
    {
        stageText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        stageText.text = stagesCompleted + "|4 Stages Completed";
    }
}