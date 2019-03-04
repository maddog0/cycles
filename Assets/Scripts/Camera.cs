using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform moon;
    // Update is called once per frame
    void Update()
    {
        transform.position = moon.position + (Vector3.back * 10);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, moon.position);
    }
}
