using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public ArrayCreation arrayObject;
    public GameObject MasterControler1;
    public GameObject MasterControler2;

    public GameObject Slider1;
    public GameObject Slider2;

    public InputHandling level1InputHandler;
    public InputHandling level2InputHandler;
    // Start is called before the first frame update
    private void Awake()
    {
        MasterControler1.GetComponent<TimerBar>().OnTimerStart();
        MasterControler2.SetActive(false);
        // Order of operations
        // Login screen setup code
    }

    // Update is called once per frame
    void Update()
    {
       // if(LoginScreenComplete && boolArray[1] == false)
       // {
             //Level one code
       // }

         if (level1InputHandler.getLeveledPassed() && !level2InputHandler.getLeveledPassed())
         {
            MasterControler1.SetActive(false);
            Slider1.SetActive(false);
            MasterControler1.GetComponent<TimerBar>().OnTimerStop();

            MasterControler2.SetActive(true);
            Slider2.SetActive(true);
            MasterControler2.GetComponent<TimerBar>().OnTimerStart();
            // Level two code
        }

        if(level2InputHandler.getLeveledPassed())
        {
            MasterControler2.SetActive(false);
            Slider2.SetActive(false);
            MasterControler2.GetComponent<TimerBar>().OnTimerStop();
            Debug.Log("end game");
        }


    }
}
