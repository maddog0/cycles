using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDebris : MonoBehaviour
{
    public GameObject debrisA;
    public int randomness=1;
    public int spanws=2;

    private GameObject menu;
    private Pause pause;
    private StartOptions startScript;

    // Awake is called before Start()
    void Awake()
    {
        menu = GameObject.Find("Menu UI");
        pause = menu.GetComponent<Pause>();
        startScript = menu.GetComponent<StartOptions>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !startScript.inMainMenu && !pause.checkPaused())
        {
            for (int i = 0; i < spanws; i++)
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
