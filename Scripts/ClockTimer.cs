using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockTimer : MonoBehaviour
{
    // This is the countdown time per sec
     float Dtime = 5;

    void Update()
    {
        if (GlobalVars.ClockActive == true)
        {
            Dtime -= Time.deltaTime;
            if (Dtime <= 0.0f)
            {
                // sets time to 0 if it is 24 
                if (GlobalVars.CurrentTime == 24)
                {
                    GlobalVars.CurrentTime = 0;
                }
                GlobalVars.CurrentTime++;

                //Debug.Log("Time" + GlobalVars.CurrentTime);
                //Debug.Log("TimeCON" + MilitaryConvert());
                //Debug.Log("TimeMIL" + GlobalVars.CurrentTime);

                // Set to the same as above
                Dtime = 5;

            }
        }
    }
    // this convertes the time to normal non military time, only goes by hour for now. Uses if statements to work, returns the converted time, could be better

    // Returns AM or PM from the time
  public string MilitaryConvertAMPM()
    {
        if(GlobalVars.CurrentTime < 12)
        {
            return "AM";
        }
        else
        {
            return "PM";
        }
    }
  public int MilitaryConvert()
    {
        int Rtime = GlobalVars.CurrentTime;
        if (GlobalVars.CurrentTime == 0) {
            Rtime = 12;
        }
        else if (GlobalVars.CurrentTime == 1)
        {
            Rtime = 1;
        }
        else if (GlobalVars.CurrentTime == 2)
        {
            Rtime = 2;
        }
        else if (GlobalVars.CurrentTime == 3)
        {
            Rtime = 3;
        }
        else if (GlobalVars.CurrentTime == 4)
        {
            Rtime = 4;
        }
        else if (GlobalVars.CurrentTime == 5)
        {
            Rtime = 5;
        }
        else if (GlobalVars.CurrentTime == 6)
        {
            Rtime = 6;
        }
        else if (GlobalVars.CurrentTime == 7)
        {
            Rtime = 7;
        }
        else if (GlobalVars.CurrentTime == 8)
        {
            Rtime = 8;
        }
        else if (GlobalVars.CurrentTime == 9)
        {
            Rtime = 9;
        }
        else if (GlobalVars.CurrentTime == 10)
        {
            Rtime = 10;
        }
        else if (GlobalVars.CurrentTime == 11)
        {
            Rtime = 11;
        }
        else if (GlobalVars.CurrentTime == 12)
        {
            Rtime = 12;
        }
        else if (GlobalVars.CurrentTime == 13)
        {
            Rtime = 1;
        }
        else if (GlobalVars.CurrentTime == 14)
        {
            Rtime = 2;
        }
        else if (GlobalVars.CurrentTime == 15)
        {
            Rtime = 3;
        }
        else if (GlobalVars.CurrentTime == 16)
        {
            Rtime = 4;
        }
        else if (GlobalVars.CurrentTime == 17)
        {
            Rtime = 5;
        }
        else if (GlobalVars.CurrentTime == 18)
        {
            Rtime = 6;
        }
        else if (GlobalVars.CurrentTime == 19)
        {
            Rtime = 7;
        }
        else if (GlobalVars.CurrentTime == 20)
        {
            Rtime = 8;
        }
        else if (GlobalVars.CurrentTime == 21)
        {
            Rtime = 9;
        }
        else if (GlobalVars.CurrentTime == 22)
        {
            Rtime = 10;
        }
        else if (GlobalVars.CurrentTime == 23)
        {
            Rtime = 11;
        }
        else if (GlobalVars.CurrentTime == 24)
        {
            Rtime = 12;
        }
        return Rtime;
    }

}


