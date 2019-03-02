using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDebris : MonoBehaviour
{
    public GameObject debrisA;
    public int randomness;
    public int spanws=5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            for (int i = 0;i<spanws;i++)
            {
                Debug.Log("left mouse clicked");

                Vector3 position = transform.position - transform.forward + Random.insideUnitSphere * randomness;
                position.z = 0;

                Instantiate(debrisA, position, transform.rotation);
            }
        }
    }
}
