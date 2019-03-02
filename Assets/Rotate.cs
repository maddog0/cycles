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
    int iteration = 0;
    public int trajLength = 50;
    public LineRenderer trajectory;

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
        if (distance < 0)
        {
            distance = 0;
        }

        //Orbit function
        Vector3 relativePos = (target.position - transform.position);
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.forward);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, (Time.deltaTime / (distance + 40)) * speed * 20);

        transform.Translate(0, 0, speed*Time.deltaTime);

        //Trajectory line function
        trajectory.positionCount = 1;
        trajectory.SetPosition(0, transform.position);
        iteration = 1;
        float cDVtemp = currentDistanceVelocity;
        float distancetemp = distance;
        Vector3 rPtemp = transform.position;
        Quaternion ctemp = transform.localRotation;
        while (iteration < trajLength)
        {
            cDVtemp -= distanceDecelerationRate * Time.deltaTime;
            cDVtemp = Mathf.Clamp(cDVtemp, initialDistanceVelocity, finalDistanceVelocity);
            distancetemp += cDVtemp;
            if (distancetemp < 0)
            {
                distancetemp = 0;
            }
            Quaternion rotationtemp = Quaternion.LookRotation(rPtemp, Vector3.forward);
            ctemp = Quaternion.Slerp(ctemp, rotationtemp, (Time.deltaTime / (distance + 40)) * speed * 20);
            rPtemp += (ctemp * Vector3.back) * speed * Time.deltaTime;
            trajectory.positionCount = iteration + 1;
            trajectory.SetPosition(iteration, rPtemp);
            iteration += 1;
        }
    }
}
