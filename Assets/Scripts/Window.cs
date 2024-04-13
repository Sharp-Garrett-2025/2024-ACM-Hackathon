using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    public Button closeButton;
    public Button okButton;

    public WindowManager windowManager;

    protected virtual void Awake()
    {
        closeButton.onClick.AddListener(Close);
        okButton.onClick.AddListener(OnOkClicked);
        if (windowManager != null)
        {
            windowManager.RegisterWindow(this);
        }
        Open();
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        Debug.Log("Close Clicked!");
        gameObject.SetActive(false);
    }

    protected abstract void OnOkClicked();
}
