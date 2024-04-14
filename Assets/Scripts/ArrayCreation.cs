using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ArrayCreation : MonoBehaviour
{
    //we create 
    public int[] numArray;

    public void Awake()
    {
        for (int i = 0; i < numArray.Length; i++) 
        {
            numArray[i] = UnityEngine.Random.Range(0, 3);
        }
    }

    public int[] GetNumArray()
    {
        return numArray;
    }
    // Update is called once per frame
}
