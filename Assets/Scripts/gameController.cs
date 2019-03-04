using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject debrisA;
    public int randomness=1;
    public int spanws = 5;

    public GUIText gameOverText;
    public GUIText restartText;

    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameOverText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
