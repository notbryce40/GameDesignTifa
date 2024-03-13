using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is where Global vars are stored
public class GlobalVars : MonoBehaviour
{
    //It is easy to store time in military, conversions would be needed
    public static int CurrentTime = 0;

    // Toggles the clock counter on
    public static bool ClockActive = true;

    // Keeps the days,starts at one
    public static int Days = 1;



    /*
    // This is a way that you can use funcations from other locations
    public ClockTimer CTtimer;
    public int MilitaryConvertReturn()
    {
      int Re =  CTtimer.MilitaryConvert();
        return Re;
    }

    but calling this also works and looks nicer
    just make sure to put the public thing at the start of the class, see FunctionTesting
    public ClockTimer CTtimer;
    int Re = CTtimer.MilitaryConvert();
    */

}
