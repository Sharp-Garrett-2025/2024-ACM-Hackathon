using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;
//oh mein good ze system iss modular undt vorkingkt
public class InputHandling : MonoBehaviour
{
    public ArrayCreation arrayObject;
    public int[] numArray;
    public GameObject[] arrowPrefabs;
    private GameObject[] instantiatedArrows;
    public Vector3 startPosition;
    public int index = 0;
    public int length;
    public Sprite[] yellowSpriteArray;
    public Sprite[] redSpriteArray;
    public float xOffSet = 0.6f;
    public float yOffSet = 0f;
    public WindowManager windowManager;
    public bool levelPassed = false;
    public AudioClip wrongArrow; // Assign this in the Inspector
    private AudioSource audioSource;
    public AudioClip correctArrow;
    public TimerBar timeThing;


    // Start is called before the first frame update

    private void Start()
    {
        GameObject windowManager = GameObject.Find("Window Manager");
        numArray = arrayObject.GetNumArray();
        instantiatedArrows = new GameObject[numArray.Length];
        length = numArray.Length;
        Draw(ref xOffSet, ref yOffSet);
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) && windowManager.popupActive != true)
        {
            if (index <= numArray.Length - 1 && numArray[index] == 0)
            {
                UpdateArrow(index, true);
                audioSource.clip = correctArrow;
                audioSource.Play();
                index++;
            }
            else {UpdateArrow(index, false);}
        }
        //else {audioSourceBlock.PlayOneShot(blockSound);}
        if (Input.GetKeyDown(KeyCode.A) && windowManager.popupActive != true)
        {
            if (index <= numArray.Length - 1 && numArray[index] == 1)
            {
                UpdateArrow(index, true);
                audioSource.clip = correctArrow;
                audioSource.Play();
                index++;
            }
            else
            {UpdateArrow(index, false);}
        }
        //else { audioSourceBlock.PlayOneShot(blockSound);}
        if (Input.GetKeyDown(KeyCode.S) && windowManager.popupActive != true)
        {
            if (index <= numArray.Length - 1 && numArray[index] == 2)
            {
                UpdateArrow(index, true);
                audioSource.clip = correctArrow;
                audioSource.Play();
                index++;
            }
            else {UpdateArrow(index, false);}
        }
       // else { audioSourceBlock.PlayOneShot(blockSound); }
        if ( Input.GetKeyDown(KeyCode.D) && windowManager.popupActive != true)
        {
            if (index <= numArray.Length - 1 && numArray[index] == 3)
            {
                UpdateArrow(index, true);
                audioSource.clip = correctArrow;
                audioSource.Play();
                index++;
            }
            else { UpdateArrow(index, false);}
        }
        //else { audioSourceBlock.PlayOneShot(blockSound); }
        if (index == numArray.Length)
        {
            levelPassed = true;
        }
    }
void Draw(ref float xOffSet, ref float yOffSet)
{
    float xIterator = 0; // Initialize xIterator to 0
    for (int i = 0; i < numArray.Length; i++)
    {
        // Calculate the spawn position for each arrow
        Vector3 spawnPosition = startPosition + new Vector3(xOffSet * xIterator, yOffSet);

        // Instantiate the arrow at the calculated position
        instantiatedArrows[i] = Instantiate(arrowPrefabs[numArray[i]], spawnPosition, Quaternion.identity);
        instantiatedArrows[i].transform.SetParent(this.transform);

        // Increment the xIterator for the next arrow's position
        xIterator++;

        // Check if the row should be changed (every 10 arrows, starting after the 10th arrow)
        if (i != 0 && (i + 1) % 10 == 0)
        {
            yOffSet -= 0.7f; // Move the next row down
            xIterator = 0; // Reset the horizontal position for the new row
        }
        
    }
}


    void UpdateArrow(int i, bool correctInput)
    {
        if (instantiatedArrows[i] != null)
        {
            // Get ze kurrent position uff ze arrow before destroyingkt it
            Vector3 currentPosition = instantiatedArrows[i].transform.position;

            // Destroy ze old arrow
            Destroy(instantiatedArrows[i]);

            // Instantiate ze new arrow at ze same position as ve are chust r-r-redrawingkt a yellow arrow in ze same place
            instantiatedArrows[i] = Instantiate(arrowPrefabs[numArray[i]], currentPosition, Quaternion.identity); //Oh hi Josh
            instantiatedArrows[i].transform.SetParent(this.transform);

            // Ve khange ze spriteR-r-renderingkt Komponent usingkt an array uff sprite r-r-renders makingkt a logical association mitt ze index uff ze array to vhich arrow ve use
            SpriteRenderer spriteRenderer = instantiatedArrows[i].GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && correctInput)
            {
                spriteRenderer.sprite = yellowSpriteArray[numArray[i]]; //numArray[i] r-r-returns an int schtored in ze array vhich zen picks out ze associated arrow from our arrow array, pretty kool huh!
                Vector3 currentScale = spriteRenderer.transform.localScale; // Get current scale
                Vector3 addedScale = new Vector3(currentScale.x * 1.2f, currentScale.y * 1.2f, currentScale.z * 1.2f); // Scale up by 1.5 times
                spriteRenderer.transform.localScale = addedScale; // Apply the new scale
            }
            else
            {
                spriteRenderer.sprite = redSpriteArray[numArray[i]];
                audioSource.clip = wrongArrow;
                audioSource.Play();
                if (timeThing != null)
                {
                    timeThing.subtractTime();
                }
            }
        }
    }

    public bool getLeveledPassed()
    {
        return levelPassed;
    }

}
