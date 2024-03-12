using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is where Global vars are stored
public class GlobalVars : MonoBehaviour
{
    //It is easy to store time in military, conversions would be needed
    public static int CurrentTime = 0;

    // Toggles the clock
    public static bool ClockActive = true;



    /*
    // This is a way that you can use funcations from other locations
    public ClockTimer CTtimer;
    public int MilitaryConvertReturn()
    {
      int Re =  CTtimer.MilitaryConvert();
        return Re;
    }
    */

}
