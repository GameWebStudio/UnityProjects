using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; //namespace to fetch Unity types like UnityEngine.MonoBehaviour

public class Clock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    const float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f; //number of degrees per hour is always the same

    [SerializeField] //Fields are private by default, serializing it means that it will be included in the scene's data and you can see the field in UnityEditor
    Transform hoursPivot, minutesPivot, secondsPivot; //synatic sugar over copying the same attribute, access modifier, and type 

    // Update is called once per frame. A frame is usually an update then render the frame
    void Update() //morer flexible than Awake method, both arer special unity event method so don't have to be public
    {
        Debug.Log(DateTime.Now); //see in Console in Editor after play mode
        //change the rotation of a Transform by assigning a new one to its localRotation property
        //DateTime time = DateTime.Now; //could also do var here due to inference
        TimeSpan time = DateTime.Now.TimeOfDay; //This will result in compiler errors, complaining that we cannot convert from double to float. This happens because the TimeSpan properties produce values with the double-precision floating point type, known as double. These values provide higher precision than float values, but Unity's code only works with single-precision floating point values.
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegrees * (float)time.TotalHours); //struct value with 30 degree clockwise rotation around the Z axis
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * (float)time.TotalMinutes); //struct value with 30 degree clockwise rotation around the Z axis
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * (float)time.TotalSeconds); //struct value with 30 degree clockwise rotation around the Z axis
    }

}
