using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform target;
    public int speed;
    public int distance;

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = (target.position - transform.position);
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.back);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, (Time.deltaTime / (distance + 40)) * speed * 20);
        transform.Translate(0, 0, speed*Time.deltaTime);
    }
}
