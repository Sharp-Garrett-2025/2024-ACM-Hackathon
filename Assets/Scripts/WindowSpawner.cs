using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class WindowGenerator : MonoBehaviour
{
    public GameObject[] windowPrefabs;
    public Canvas canvas;
    public WindowManager windowManager;


    public int maxWindows = 5; // Maximum number of windows allowed

    public int spawnIntervalMin = 3;
    public int spawnIntervalMax = 8;

    public bool randomizeZ = false;
    public float zPosition = -3f;
    public float zRangeMin = -5f;
    public float zRangeMax = -1f;

    public float xRangeMin = -5f;
    public float xRangeMax = 5f;
    public float yRangeMin = -3f;
    public float yRangeMax = 3f;

    int availableSlots;

    public List<GameObject> spawnedWindows = new List<GameObject>(); // Track spawned windows

    private void Start()
    {
        StartCoroutine(GenerateWindowsOverTime());
    }

    private void Update()
    {
        availableSlots = maxWindows - spawnedWindows.Count;
        CleanUpDisabledWindows(availableSlots);
    }

    IEnumerator GenerateWindowsOverTime()
    {
        while (true) // Loop indefinitely
        {
            int spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(spawnInterval);


            if (availableSlots > 0) // Only spawn if there's at least 1 slot
            {
                GameObject windowInstance = SpawnWindow();
            }
        }
    }

    private GameObject SpawnWindow()
    {
        if (spawnedWindows.Count >= maxWindows)
        {
            return null; // No slots available
        }

        GameObject windowInstance = InstantiateRandomWindow();
        windowInstance.transform.SetParent(canvas.transform, true);
        windowInstance.transform.position = GetSpawnPosition();

        windowManager.RegisterWindow(windowInstance.GetComponent<Window>());
        spawnedWindows.Add(windowInstance);
        return windowInstance;
    }

    private GameObject InstantiateRandomWindow()
    {
        int randomIndex = Random.Range(0, windowPrefabs.Length);
        return Instantiate(windowPrefabs[randomIndex]);
    }

    private Vector3 GetSpawnPosition()
    {
        float randomX = Random.Range(xRangeMin, xRangeMax);
        float randomY = Random.Range(yRangeMin, yRangeMax);
        return new Vector3(randomX, randomY, 0);
    }

    private void CleanUpDisabledWindows(int availableSlots)
    {
        // Iterate backwards for safer removal during iteration
        for (int i = spawnedWindows.Count - 1; i >= 0; i--)
        {
            GameObject window = spawnedWindows[i];
            if (!window.activeInHierarchy) // Check if disabled
            {
                spawnedWindows.RemoveAt(i);
                Destroy(window); // Destroy the disabled window

                // Unregister with WindowManager
                windowManager.UnregisterWindow(window.GetComponent<Window>());

                availableSlots++; // Update available slots
                if (availableSlots >= maxWindows) // Early exit if enough slots found
                {
                    break;
                }
            }
        }
    }
}
