using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public ArrayCreation arrayObject;
    public GameObject MasterControler0;
    public GameObject MasterControler1;
    public GameObject MasterControler2;

    public GameObject windowManager;

    public bool gameFail;
    public bool level0Pass;
    public bool level1Pass;
    public bool level2Pass;

    public bool level0Current;
    public bool level1Current;
    public bool level2Current;
    public bool endCurrent;

    public GameObject Slider1;
    public GameObject Slider2;

    public GameObject hackTextLevel1;
    public GameObject hackTextLevel2;
    public GameObject SignInScreen;
    public GameObject CMD;
    public GameObject bossPopup;
    public GameObject bossMessage;
    public GameObject endScreenImage;

    public InputHandling level0InputHandler;
    public InputHandling level1InputHandler;
    public InputHandling level2InputHandler;
    // Start is called before the first frame update
    private void Awake()
    {
        MasterControler0.SetActive(true);
        MasterControler1.SetActive(false);
        MasterControler2.SetActive(false);
        windowManager.SetActive(false);
        bossPopup.SetActive(false);
        bossMessage.SetActive(false);
        SignInScreen.SetActive(true);
        level0Current = true; 
        level1Current = false;
        level2Current = false;
        gameFail = false;
        level0Pass = false;
        level1Pass = false;
        level2Pass = false;

        endCurrent = false;
        // Order of operations
        // Login screen setup code
    }

    public void OnDesktop()
    {
        //windowManager.SetActive(true);
        MasterControler0.SetActive(false);
        SignInScreen.SetActive(false);
        // Desktop Note here
        OnClippyPart1();

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

    public void OnStartEnd()
    {
        Debug.Log("end game");
        endCurrent = true;
        CMD.SetActive(false);
        MasterControler2.SetActive(false);
        Slider2.SetActive(false);
        MasterControler2.GetComponent<TimerBar>().OnTimerStop();
        // Wait for about 4 seconds
        bossPopup.SetActive(true);
    }

    public void OnBossMessage()
    {
        bossPopup.SetActive(false);
        bossMessage.SetActive(true);
    }

    public void OnEnd()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        level0Pass = level0InputHandler.getLeveledPassed();
        if (level0Pass && level0Current && !level1Current)
        {
            level1Current = true;
            OnDesktop();
        }
        if (level1InputHandler.getLeveledPassed() && !level2InputHandler.getLeveledPassed() && !level2Current)
        {
            level2Current = true;
            OnClippyPart2();
        }
        if(level2InputHandler.getLeveledPassed() && !endCurrent)
        {
            OnStartEnd();
        }


        if (MasterControler1.GetComponent<TimerBar>().gameFailed)
        {
            MasterControler1.SetActive(false);
            endScreenImage.SetActive(true);
            //show end screen

        }
        if (MasterControler2.GetComponent<TimerBar>().gameFailed)
        {
            MasterControler2.SetActive(false);
            endScreenImage.SetActive(true);
            //show end screen
        }

    }

}
