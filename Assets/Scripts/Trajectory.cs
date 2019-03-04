using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    int iteration = 0;
    public int trajLength = 5;
    public LineRenderer trajectory;
    public Rotate rotate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Trajectory line function
        trajectory.positionCount = 1;
        trajectory.SetPosition(0, transform.position);
        iteration = 1;
        float cDVtemp = rotate.currentDistanceVelocity;
        float distancetemp = rotate.distance;
        Vector3 rPtemp = transform.position;
        Quaternion ctemp = transform.localRotation;
        while (iteration < trajLength)
        {
            cDVtemp -= rotate.distanceDecelerationRate * Time.deltaTime;
            cDVtemp = Mathf.Clamp(cDVtemp, rotate.initialDistanceVelocity, rotate.finalDistanceVelocity);
            distancetemp += cDVtemp;
            if (distancetemp < 0)
            {
                distancetemp = 0;
            }
            Quaternion rotationtemp = Quaternion.LookRotation(rPtemp, Vector3.forward);
            ctemp = Quaternion.Slerp(ctemp, rotationtemp, (Time.deltaTime / (rotate.distance + 40)) * rotate.speed * 20);
            rPtemp += (ctemp * Vector3.back) * rotate.speed * Time.deltaTime;
            trajectory.positionCount = iteration + 1;
            trajectory.SetPosition(iteration, rPtemp);
            iteration += 1;
        }
    }
}
