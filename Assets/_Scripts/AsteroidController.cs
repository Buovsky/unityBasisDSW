using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private static float rotationSpeed = 50f;
    void Update()
    {
        AsteroidRotation();
        AsteroidMove();
    }

    private void AsteroidRotation()
    {
        transform.Rotate(Vector3.back * (moveSpeed * rotationSpeed * Time.deltaTime));
    }

    private void AsteroidMove()
    {
        transform.position += Vector3.down * (moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(this.gameObject);
    }
}
