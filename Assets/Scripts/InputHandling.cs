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
    public float xOffSet = 1.2f;
    public float yOffSet = 0f;
    // Start is called before the first frame update

    private void Start()
    {
        numArray = arrayObject.GetNumArray();
        boolArray = arrayObject.GetBoolArray();
        instantiatedArrows = new GameObject[numArray.Length];
        startPosition = new Vector2(-5, 0);
        Draw(ref xOffSet, ref yOffSet);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (index <= numArray.Length - 1 && numArray[index] == 0)
            {
                boolArray[index] = true;
                UpdateArrow(index);
                index++;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (index <= numArray.Length - 1 && numArray[index] == 1)
            {
                boolArray[index] = true;
                UpdateArrow(index);
                index++;
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            if (index <= numArray.Length - 1 && numArray[index] == 2)
            {
                boolArray[index] = true;
                UpdateArrow(index);
                index++;
            }
        }
        if( Input.GetKeyDown(KeyCode.D))
        {
            if (index <= numArray.Length - 1 && numArray[index] == 3)
            {
                boolArray[index] = true;
                UpdateArrow(index);
                index++;
            }
        }
    }
void Draw(ref float xOffSet, ref float yOffSet)
{
    float xIterator = 0; // Initialize xIterator to 0
    for (int i = 0; i < numArray.Length; i++)
    {
        // Calculate the spawn position for each arrow
        Vector2 spawnPosition = startPosition + new Vector2(xOffSet * xIterator, yOffSet);

        // Instantiate the arrow at the calculated position
        instantiatedArrows[i] = Instantiate(arrowPrefabs[numArray[i]], spawnPosition, Quaternion.identity);
        instantiatedArrows[i].transform.SetParent(this.transform);

        // Increment the xIterator for the next arrow's position
        xIterator++;

        // Check if the row should be changed (every 10 arrows, starting after the 10th arrow)
        if (i != 0 && (i + 1) % 10 == 0)
        {
            yOffSet -= 1.0f; // Move the next row down
            xIterator = 0; // Reset the horizontal position for the new row
        }
    }
}


    void UpdateArrow(int i)
    {
        if (instantiatedArrows[i] != null)
        {
            // Get ze kurrent position uff ze arrow before destroyingkt it
            Vector2 currentPosition = instantiatedArrows[i].transform.position;

            // Destroy ze old arrow
            Destroy(instantiatedArrows[i]);

            // Instantiate ze new arrow at ze same position as ve are chust r-r-redrawingkt a yellow arrow in ze same place
            instantiatedArrows[i] = Instantiate(arrowPrefabs[numArray[i]], currentPosition, Quaternion.identity); //Oh hi Josh
            instantiatedArrows[i].transform.SetParent(this.transform);

            // Ve khange ze spriteR-r-renderingkt Komponent usingkt an array uff sprite r-r-renders makingkt a logical association mitt ze index uff ze array to vhich arrow ve use
            SpriteRenderer spriteRenderer = instantiatedArrows[i].GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = yellowSpriteArray[numArray[i]]; //numArray[i] r-r-returns an int schtored in ze array vhich zen picks out ze associated arrow from our arrow array, pretty kool huh!
            }
        }
    }
}
