using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform[] lanes;
    private int currentLane = 1;
    private int targetLane = 1;
    private bool isChangingLane = false;
    private bool isMoving = false;
    private Vector3 startPosition;

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
                    // Przesunięcie w lewo
                    targetLane = Mathf.Clamp(currentLane - 1, 0, lanes.Length - 1);
                }
                else if (swipeDirection.x > 0f)
                {
                    // Przesunięcie w prawo
                    targetLane = Mathf.Clamp(currentLane + 1, 0, lanes.Length - 1);
                }

                if (targetLane != currentLane)
                {
                    StartCoroutine(MoveToLane(targetLane));
                }
            }
        }
    }

    private IEnumerator MoveToLane(int targetLane)
    {
        isChangingLane = true;

        float startX = transform.position.x;
        float targetX = lanes[targetLane].position.x;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * moveSpeed;
            float newX = Mathf.Lerp(startX, targetX, t);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            yield return null;
        }

        currentLane = targetLane;
        isChangingLane = false;
    }
}
