using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public const int hoursInDay = 24, minutesInHour = 60;
    public float dayDuration = 1440f; // Duration of a day in seconds

    float totalTime; // Total time since the start of the game
    float currentTime; // Current time within the day

    bool endofDay = false; // Flag to indicate the end of the day

    // Start is called before the first frame update
    void Start()
    {
        // Initialize totalTime to 9 AM
        totalTime = dayDuration * (9f / 24f);
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        currentTime = totalTime % dayDuration;

        // Check if the current time is 5 PM or later
        if (GetHour() >= 17)
        {
            // Trigger an alert
            Debug.Log("It's 5 PM!");
            // Prevent further alerts by stopping the time or setting a flag
            // This is just an example, you'll need to implement a proper mechanism
            this.enabled = false; // Disable this script

            endofDay = true;
        }
    }

    public float GetHour()
    {
        return currentTime * hoursInDay / dayDuration;
    }

    public float GetMinutes()
    {
        return (currentTime * hoursInDay * minutesInHour / dayDuration) % minutesInHour;
    }

    public string Clock24Hour()
    {
        // Format the time as HH:MM
        return Mathf.FloorToInt(GetHour()).ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00");
    }

    public string Clock12Hour()
    {
        int hour = Mathf.FloorToInt(GetHour());
        string abbreviation = "AM";

        if (hour >= 12)
        {
            abbreviation = "PM";
            if (hour > 12) hour -= 12;
        }

        if (hour == 0) hour = 12;

        return hour.ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00") + " " + abbreviation;
    }
}
