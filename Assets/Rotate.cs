using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform target;
    public int speed;
    public float distance;
    public float initialDistanceVelocity = -100.0f;
    public float finalDistanceVelocity = 100.0f;
    public float currentDistanceVelocity = 0.0f;
    float distanceAccelerationRate = 0.01f;
    public float distanceDecelerationRate = 0.001f;

    // Update is called once per frame
    void Update()
    {
        //Acceleration function
        if (Input.GetMouseButton(0))
        {
            currentDistanceVelocity = currentDistanceVelocity + (distanceAccelerationRate * Time.deltaTime);
        }
        else
        {
            currentDistanceVelocity = currentDistanceVelocity - (distanceDecelerationRate * Time.deltaTime);
        }

        currentDistanceVelocity = Mathf.Clamp(currentDistanceVelocity, initialDistanceVelocity, finalDistanceVelocity);

        distance += currentDistanceVelocity;
        if (distance < transform.lossyScale.x)
        {
            distance = transform.lossyScale.x;
        }

        //Orbit function
        Vector3 relativePos = (target.position - transform.position);
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, (Time.deltaTime / (distance * 2)) * speed * 5);

        transform.Translate(0, 0, speed*Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GAME OVER MAN");
    }
}
