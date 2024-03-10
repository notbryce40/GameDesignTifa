using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTimer : MonoBehaviour
{
    // This is the countdown time
     float Dtime = 1;
    // Update is called once per frame
    void Update()
    {
        Dtime -= Time.deltaTime;
        if (Dtime <= 0.0f)
        {
            GlobalVars.CurrentTime++;
            Debug.Log("Time" + GlobalVars.CurrentTime);
            Dtime = 5;
        }
    }
}
