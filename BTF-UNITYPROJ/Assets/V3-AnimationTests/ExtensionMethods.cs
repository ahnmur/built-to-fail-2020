using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{

//https://forum.unity.com/threads/re-map-a-number-from-one-range-to-another.119437/

public static float Remap(this float value, float from1, float to1, float from2, float to2)
{
    return (value - from1)/(to1 - from1) * (to2-from2) + from2;
}

public static float Multiply(this float value, float multiplier)
{
    return (value) * multiplier;
}


}

// // Original values were x, 1, 5, 0, 1
// (x - 1)/(5 - 1) * (1-0) + 0
// = essentially (value - from1)/(to1 - from1) 
// = (value - 1) / (5-1)

