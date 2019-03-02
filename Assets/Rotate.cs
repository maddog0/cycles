using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform target;
    public int speed;
    public float distance;
    float initialDistanceVelocity = -100.0f;
    float finalDistanceVelocity = 100.0f;
    public float currentDistanceVelocity = 0.0f;
    float distanceAccelerationRate = 0.01f;
    float distanceDecelerationRate = 0.001f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            currentDistanceVelocity = currentDistanceVelocity + (distanceAccelerationRate * Time.deltaTime);
        }
        else
        {
            currentDistanceVelocity = currentDistanceVelocity - (distanceDecelerationRate * Time.deltaTime);
        }

        currentDistanceVelocity = Mathf.Clamp(currentDistanceVelocity, initialDistanceVelocity, finalDistanceVelocity);

        Vector3 relativePos = (target.position - transform.position);
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);

        Quaternion current = transform.localRotation;

        distance += currentDistanceVelocity;
        if (distance < 0)
        {
            distance = 0;
        }

        transform.localRotation = Quaternion.Slerp(current, rotation, (Time.deltaTime / (distance + 40)) * speed * 20);

        transform.Translate(0, 0, speed*Time.deltaTime);
    }
}
