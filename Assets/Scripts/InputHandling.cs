using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
//oh mein good ze system iss modular undt vorkingkt
public class InputHandling : MonoBehaviour
{
    public ArrayCreation arrayObject;
    public bool[] boolArray;
    public int[] numArray;
    public GameObject[] arrowPrefabs;
    private GameObject[] instantiatedArrows;
    public Vector2 startPosition;
    int index = 0;
    public Color newColor = Color.yellow;
    public Sprite[] yellowSpriteArray;
    //int[] numArray = arrayObject.GetNumArray();
    // Start is called before the first frame update

    private void Start()
    {
        numArray = arrayObject.GetNumArray();
        boolArray = arrayObject.GetBoolArray();
        instantiatedArrows = new GameObject[numArray.Length];
        startPosition = new Vector2(-5, 0);
        Draw();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (index <= numArray.Length - 1 && numArray[index] == 0)
            {
                Debug.Log("upArrow");
                Debug.Log("success");
                boolArray[index] = true;
                UpdateArrow(index);
                index++;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (index <= numArray.Length - 1 && numArray[index] == 1)
            {
                Debug.Log("leftArrow");
                Debug.Log("success");
                boolArray[index] = true;
                UpdateArrow(index);
                index++;
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            if (index <= numArray.Length - 1 && numArray[index] == 2)
            {
                Debug.Log("downArrow");
                Debug.Log("success");
                boolArray[index] = true;
                UpdateArrow(index);
                index++;
            }
        }
        if( Input.GetKeyDown(KeyCode.D))
        {
            if (index <= numArray.Length - 1 && numArray[index] == 3)
            {
                Debug.Log("rightArrow");
                Debug.Log("success");
                boolArray[index] = true;
                UpdateArrow(index);
                index++;
            }
        }
    }
    void Draw()
    {
        float offset = 1.2f;
        for(int i = 0; i < numArray.Length; i++)
        {
            if (boolArray[i] == false)
            {
                //Debug.Log("WhiteArrow");
                Vector2 spawnPosition = startPosition + new Vector2(offset * i, 0);
                instantiatedArrows[i] = Instantiate(arrowPrefabs[numArray[i]], spawnPosition, Quaternion.identity);
                instantiatedArrows[i].transform.SetParent(this.transform);
            }
            else
            {
                //Debug.Log("YellowArror");
                // Needs color still
                Vector2 spawnPosition = startPosition + new Vector2(offset * i, 0);
                instantiatedArrows[i] = Instantiate(arrowPrefabs[numArray[i]], spawnPosition, Quaternion.identity);
                instantiatedArrows[i].transform.SetParent(this.transform);

            }
            //startPosition += new Vector2(100, 0);
        }
    }

    void UpdateArrow(int i)
    {
        if (instantiatedArrows[i] != null)
            Destroy(instantiatedArrows[i]); // Ensure the old arrow is destroyed.
        float offset = 1.2f;
        Vector2 spawnPosition = startPosition + new Vector2(offset * i, 0);
        instantiatedArrows[i] = Instantiate(arrowPrefabs[numArray[i]], spawnPosition, Quaternion.identity);
        instantiatedArrows[i].transform.SetParent(this.transform);
        SpriteRenderer spriteRenderer = instantiatedArrows[i].GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = yellowSpriteArray[numArray[i]];  // Set the color to yellow, or any other color as needed
        }
    }
}
