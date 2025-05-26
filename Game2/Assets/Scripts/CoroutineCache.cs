using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CoroutineCache : MonoBehaviour
{
    static Dictionary<float, WaitForSeconds> dictionary = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds WaitForSecond(float time)
    {
        WaitForSeconds waitForseconds;

        if (dictionary.TryGetValue(time, out waitForseconds) == false)
        {
            dictionary.Add(time, new WaitForSeconds(time));

            waitForseconds = dictionary[time];
        }

        return waitForseconds;
    }
}
