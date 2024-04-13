using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowManager : MonoBehaviour
{
    public List<Window> windows;

    private Window currentFocusedWindow;

    public void RegisterWindow(Window window)
    {
        windows.Add(window);
    }

    public void UnregisterWindow(Window window)
    {
        windows.Remove(window);
    }

    public void FocusWindow(Window window)
    {
        if (currentFocusedWindow != null)
        {
            // Do something to visually indicate loss of focus 
        }

        currentFocusedWindow = window;
        // Do something to visually indicate focus gain
    }
}
