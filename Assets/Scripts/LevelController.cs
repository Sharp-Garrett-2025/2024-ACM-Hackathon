using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public ArrayCreation arrayObject;
    public GameObject MasterControler1;
    public GameObject MasterControler2;

    public bool level1Current;
    public bool level2Current;

    public GameObject Slider1;
    public GameObject Slider2;

    public GameObject hackTextLevel1;
    public GameObject hackTextLevel2;

    public InputHandling level1InputHandler;
    public InputHandling level2InputHandler;
    // Start is called before the first frame update
    private void Awake()
    {
        MasterControler1.SetActive(false);
        MasterControler2.SetActive(false);
        // Order of operations
        // Login screen setup code
    }

    public void OnClippyPart1()
    {
        hackTextLevel1.SetActive(true);
    }

    public void OnClippyPart2()
    {
        MasterControler1.SetActive(false);
        Slider1.SetActive(false);
        MasterControler1.GetComponent<TimerBar>().OnTimerStop();
        hackTextLevel2.SetActive(true);
    }

    public void OnStartLevel1()
    {
        Debug.Log("Level1 Started");
        level1Current = true;
        hackTextLevel1.SetActive(false);
        MasterControler1.SetActive(true);
        Slider1.SetActive(true);
        MasterControler1.GetComponent<TimerBar>().OnTimerStart();
    }

    public void OnStartLevel2()
    {
        Debug.Log("Level1 Started");
        level2Current = true;
        hackTextLevel2.SetActive(false);
        MasterControler2.SetActive(true);
        Slider2.SetActive(true);
        MasterControler2.GetComponent<TimerBar>().OnTimerStart();
    }
    // Update is called once per frame
    void Update()
    {
       if(!level1InputHandler.getLeveledPassed() && !level1Current)
       {
            OnClippyPart1();
       }

        if (level1InputHandler.getLeveledPassed() && !level2InputHandler.getLeveledPassed() && !level2Current)
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
