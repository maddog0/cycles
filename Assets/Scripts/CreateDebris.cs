using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDebris : MonoBehaviour
{
    public GameObject debrisA;
    public int randomness=1;
    public int spanws=2;

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

                StartCoroutine("SpawnDebris");

            }
        }
    }
    private IEnumerator SpawnDebris()
    {
        Vector3 position = transform.position - transform.up + Random.insideUnitSphere * randomness;
        position.z = 0;

        yield return new WaitForSeconds(1);
        Instantiate(debrisA, position, transform.rotation);
    }
}
