using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPopup1 : Window
{
    protected override void OnOkClicked()
    {
        Debug.Log("Confirmation: OK");
        Close();
    }
}
