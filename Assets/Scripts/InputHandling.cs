using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class InputHandling : MonoBehaviour
{
    public ArrayCreation arrayObject;
    public bool[] boolArray;
    public int[] numArray;
    int index = 0;
    //int[] numArray = arrayObject.GetNumArray();
    // Start is called before the first frame update

    private void Start()
    {
        numArray = arrayObject.GetNumArray();
        boolArray = arrayObject.GetBoolArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (numArray[index] == 0 && index < numArray.Length -1)
            {
                Debug.Log("upArrow");
                Debug.Log("success");
                boolArray[index] = true;
                index++;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (numArray[index] == 1 && index < numArray.Length - 1)
            {
                Debug.Log("leftArrow");
                Debug.Log("success");
                boolArray[index] = true;
                index++;
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            if (numArray[index] == 2 && index < numArray.Length - 1)
            {
                Debug.Log("downArrow");
                Debug.Log("success");
                boolArray[index] = true;
                index++;
            }
        }
        if( Input.GetKeyDown(KeyCode.D))
        {
            if (numArray[index] == 3 && index < numArray.Length - 1)
            {
                Debug.Log("rightArrow");
                Debug.Log("success");
                boolArray[index] = true;
                index++;
            }
        }
        Draw(numArray,boolArray);
    }
    void Draw(int[] numArray, bool[] boolArray)
    {
        foreach(int i in numArray)
        {
            if (boolArray[i] == false)
            {
                Debug.Log("WhiteArrow");
                //need to schow arrow as vite
                //ve need zome caze schtadement to chooze direczion und dedermine ein vay to Hiderate across zee screen
            }
            else
            {
                Debug.Log("YellowArror");
                //need to schow arrow as yellow
                //ve need zome caze schtadement to chooze direczion und dedermine ein vay to Hiderate across zee screen

            }
        }
    }
}
