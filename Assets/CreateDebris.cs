﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDebris : MonoBehaviour
{
    public GameObject debrisA;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("left mouse clicked");

            Instantiate(debrisA, transform.position, transform.rotation);
        }
    }
}