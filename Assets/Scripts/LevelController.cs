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

    public GameObject hackTextLevel1;
    public GameObject hackTextLevel2;

    public InputHandling level1InputHandler;
    public InputHandling level2InputHandler;
    // Start is called before the first frame update
    private void Awake()
    {
        MasterControler2.SetActive(false);
        // Order of operations
        // Login screen setup code
    }

    public void OnClippyPart1()
    {

    }

    public void OnClippyPart2()
    {

    }

    public void OnStartLevel1()
    {
        MasterControler1.SetActive(true);
        Slider1.SetActive(true);
        MasterControler1.GetComponent<TimerBar>().OnTimerStart();
    }

    public void OnStartLevel2()
    {
        MasterControler2.SetActive(true);
        Slider2.SetActive(true);
        MasterControler2.GetComponent<TimerBar>().OnTimerStart();
    }
    // Update is called once per frame
    void Update()
    {
       if(!level1InputHandler.getLeveledPassed())
       {
            OnClippyPart1();
       }

        if (level1InputHandler.getLeveledPassed() && !level2InputHandler.getLeveledPassed())
        {
            OnClippyPart2();
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
