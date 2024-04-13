using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ArrayCreation : MonoBehaviour
{
    // Start is called before the first frame update
    int[] numArray = { 0, 2, 3, 0, 0, 1, 2, 3 };
    bool[] boolArray = { false, false, false, false, false, false, false, false };

    public void Start()
    {

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
