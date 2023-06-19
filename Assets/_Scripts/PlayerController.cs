using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 180f; 
    [SerializeField] private Transform[] lanes;
    private int currentLane = 1;
    private int targetLane = 1;
    private bool isChangingLane = false;
    private bool isRotating = false;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Quaternion targetRotation;

 private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isChangingLane)
        {
            startPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0) && !isChangingLane)
        {
            Vector3 endPosition = Input.mousePosition;
            float swipeDistance = (endPosition - startPosition).magnitude;

            if (swipeDistance > 50f)
            {
                Vector3 swipeDirection = endPosition - startPosition;

                if (swipeDirection.x < 0f)
                {
                    // Left Swipe
                    targetLane = Mathf.Clamp(currentLane - 1, 0, lanes.Length - 1);
                    targetRotation = Quaternion.Euler(0f, 0f, 45f);
                }
                else if (swipeDirection.x > 0f)
                {
                    // Right Swipe
                    targetLane = Mathf.Clamp(currentLane + 1, 0, lanes.Length - 1);
                    targetRotation = Quaternion.Euler(0f, 0f, -45f);
                }

                if (targetLane != currentLane)
                {
                    StartCoroutine(MoveAndRotateToLane(targetLane));
                }
            }
        }

        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                isRotating = false;
                transform.rotation = targetRotation;
            }
        }
    }

    private IEnumerator MoveAndRotateToLane(int targetLane)
    {
        isChangingLane = true;
        startRotation = transform.rotation;

        float startX = transform.position.x;
        float targetX = lanes[targetLane].position.x;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * moveSpeed;
            float newX = Mathf.Lerp(startX, targetX, t);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            if (t < 0.5f)
            {
                float rotationProgress = t * 2f;
                Quaternion newRotation = Quaternion.Slerp(startRotation, targetRotation, rotationProgress);
                transform.rotation = newRotation;
            }
            else
            {
                float rotationProgress = (t - 0.5f) * 2f;
                Quaternion newRotation = Quaternion.Slerp(targetRotation, Quaternion.identity, rotationProgress);
                transform.rotation = newRotation;
            }

            yield return null;
        }

        currentLane = targetLane;
        isChangingLane = false;
        isRotating = false;
    }
}