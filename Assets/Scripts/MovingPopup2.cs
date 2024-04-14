using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPopup2 : Window
{
    protected override void OnOkClicked()
    {
        Debug.Log("Confirmation: OK");
        Close();
    }

    public float movementSpeed = 2.0f;
    public Rect screenBounds; // Customizable in the Inspector

    private Vector2 movementDirection;

    void Start()
    {
        SetRandomDirection();
    }

    void Update()
    {
        transform.position += (Vector3)movementDirection * movementSpeed * Time.deltaTime;
        CheckBounds();
    }

    void SetRandomDirection()
    {
        movementDirection = Random.insideUnitCircle.normalized;
    }

    void CheckBounds()
    {
        Vector3 position = transform.position;

        // Check X-axis bounds
        if (position.x < screenBounds.xMin || position.x > screenBounds.xMax)
        {
            movementDirection.x = -movementDirection.x; // Reverse the X direction
        }

        // Check Y-axis bounds
        if (position.y < screenBounds.yMin || position.y > screenBounds.yMax)
        {
            movementDirection.y = -movementDirection.y; // Reverse the Y direction
        }
    }
}
