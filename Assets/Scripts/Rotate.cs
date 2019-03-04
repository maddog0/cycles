using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform target;
    public int speed;
    public float distance;
    public float distanceAccelerationRate = 0.01f;
    public float distanceDecelerationRate = 0.001f;
    float direction;
    float rotationSpeed;

    private ShowPanels showPanels;
    private GameObject menu;
    private Pause pause;
    private StartOptions startScript;

    // Awake is called before Start()
    private void Awake()
    {
        menu = GameObject.Find("Menu UI");
        pause = menu.GetComponent<Pause>();
        startScript = menu.GetComponent<StartOptions>();
        showPanels = menu.GetComponent<ShowPanels>();
        Time.timeScale = 0;

    }
    // Update is called once per frame
    void Update()
    {
        //Acceleration function
        if (Input.GetMouseButtonDown(0) && !startScript.inMainMenu && !pause.checkPaused())
        {
            distance += distanceAccelerationRate;
            direction = -1;
            rotationSpeed = 100;
        }
        else
        {
            distance -= (distanceDecelerationRate * Time.deltaTime) / transform.position.sqrMagnitude;
            direction = 1;
            rotationSpeed = 5;
        }

        //Orbit function
        Vector3 relativePos = (target.position - transform.position);
        Quaternion rotation = Quaternion.LookRotation(direction * relativePos, Vector3.forward);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, (Time.deltaTime / (distance * 4)) * speed * rotationSpeed);

        transform.Translate(0, 0, speed*Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0;
        showPanels.ShowGameOverPanel();
    }
}
