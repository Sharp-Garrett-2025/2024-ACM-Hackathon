using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Correct namespace for UI components like Button
// No need to use UnityEngine.UIElements unless you are using UI Toolkit.

public class TripleOrNothing : Window
{
    public Button Button1;
    public Button Button2;
    public Button Button3;


    void Start()
    {
        SetupButtons();
    }
    private void SetupButtons()
    {
        int num = UnityEngine.Random.Range(1, 4); // Correct range to include 3 as a possible value
        Button1.gameObject.SetActive(num == 1);
        Button2.gameObject.SetActive(num == 2);
        Button3.gameObject.SetActive(num == 3); // Corrected to ensure only one button is active based on the random number
    }

    protected override void OnOkClicked()
    {
        Debug.Log("Confirmation: OK");
        Close();
    }
}