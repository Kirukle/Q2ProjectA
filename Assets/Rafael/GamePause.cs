using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerPause;
    public bool Paused;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape) && Paused == false)
        {

            Pause();

        }

        if (Input.GetKeyUp(KeyCode.Escape) && Paused == true)
        {

            Resume();

        }


    }

    void Pause()
    {
        Paused = true;
        PlayerPause.GetComponent<Jumpy>().enabled = false;
        PlayerPause.GetComponent<Jumpy>().enabled = false;
    }

    void Resume()
    {
        Paused = false;
        PlayerPause.GetComponent<Jumpy>().enabled = true;
        PlayerPause.GetComponent<Jumpy>().enabled = true;
    }
}
