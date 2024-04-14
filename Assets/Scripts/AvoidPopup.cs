using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidPopup : MovingPopup2
{
    public float cursorAvoidanceDistance = 2.0f;

    void Update()
    {
        transform.position += (Vector3)movementDirection * movementSpeed * Time.deltaTime;
        CheckBounds();
        SteerAwayFromCursor();
    }

    void SteerAwayFromCursor()
    {
        // Get the cursor position in world space
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = transform.position.z; // Match Z plane

        // Check if the cursor is too close
        float distanceToCursor = Vector3.Distance(transform.position, cursorPosition);
        if (distanceToCursor < cursorAvoidanceDistance)
        {
            // Calculate a direction away from the cursor
            Vector3 directionAway = transform.position - cursorPosition;
            movementDirection = directionAway.normalized;
        }
    }
}
