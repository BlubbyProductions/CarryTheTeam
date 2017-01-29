using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{

    private float Timer;
    private float minute;
    private float second;
    private float timeTracker;
    private bool startClock;

	// Use this for initialization
	void Start ()
    {
        minute = 3;
        second = 0;
        timeTracker = 1;
        startClock = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    // check if a second has passed, if yes, countdown
        //if(Time.time > timeTracker && startClock)
        if (Time.time > timeTracker)
        {
            timeTracker = Mathf.Floor(timeTracker + 1);
            
            if (second <= 0)
            {
                minute -= 1;
                second = 59;
            }
            else
            {
                second -= 1;
            }

            Debug.Log ("Clock: " + minute + ":" + second);
        }
	}

    void StartClock ()
    {
        startClock = true;
        timeTracker += Time.time;
    }

    void ResetClock ()
    {
        minute = 3;
        second = 0;
        timeTracker = 1;
        startClock = false;
    }
}
