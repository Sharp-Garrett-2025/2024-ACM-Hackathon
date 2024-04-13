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
    int[] numArray;
    bool[] boolArray;

    public void Awake()
    {
        numArray = new int[50];
        boolArray = new bool[50];
        for (int i = 0; i < numArray.Length; i++) 
        {
            numArray[i] = UnityEngine.Random.Range(0, 3);
            boolArray[i] = false;
        }
    }

    public int[] GetNumArray()
    {
        return numArray;
    }
    public bool[] GetBoolArray() 
    {
        return boolArray;
    }
    // Update is called once per frame
}
