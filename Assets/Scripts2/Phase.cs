using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Phase : MonoBehaviour
{
    public TMP_Text phaseDisplayText; 
    private Touch theTouch; 
    private float timeTouchEnded; 
    private float displayTime = 0.5f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            phaseDisplayText.text = theTouch.phase.ToString();

            if (theTouch.phase == TouchPhase.Ended )
            {
                timeTouchEnded = Time.time;
            }
        }
        else if (Time.time - timeTouchEnded > displayTime)
        {
            phaseDisplayText.text = "";
        }
    }
}
