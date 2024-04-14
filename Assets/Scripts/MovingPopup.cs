using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPopup : Window
{
    protected override void OnOkClicked()
    {
        Debug.Log("Confirmation: OK");
        Close();
    }

    public float movementSpeed = 2.0f;
    public float movementRange = 2.0f;

    private Vector3 initialPosition;
    private float offset = 0f;

    void Start()
    {
        initialPosition = transform.position;
        offset = Random.value; // Slight randomization of movement pattern
    }

    void Update()
    {
        float x = initialPosition.x + movementRange * Mathf.Sin(Time.time * movementSpeed + offset);
        float y = initialPosition.y + movementRange * Mathf.Sin(Time.time * movementSpeed + offset);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
